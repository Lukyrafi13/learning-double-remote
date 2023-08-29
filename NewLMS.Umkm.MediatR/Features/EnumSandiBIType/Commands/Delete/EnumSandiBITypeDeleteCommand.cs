using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Commands
{
    public class EnumSandiBITypeDeleteCommand : EnumSandiBITypeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteEnumSandiBITypeCommandHandler : IRequestHandler<EnumSandiBITypeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<EnumSandiBIType> _EnumSandiBIType;
        private readonly IMapper _mapper;

        public DeleteEnumSandiBITypeCommandHandler(IGenericRepositoryAsync<EnumSandiBIType> EnumSandiBIType, IMapper mapper){
            _EnumSandiBIType = EnumSandiBIType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(EnumSandiBITypeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _EnumSandiBIType.GetByIdAsync(request.BI_TYPE, "BI_TYPE");
            rFProduct.IsDeleted = true;
            await _EnumSandiBIType.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}