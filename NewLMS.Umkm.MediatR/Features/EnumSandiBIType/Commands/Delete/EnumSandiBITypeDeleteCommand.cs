using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.EnumSandiBITypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBITypes.Commands
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