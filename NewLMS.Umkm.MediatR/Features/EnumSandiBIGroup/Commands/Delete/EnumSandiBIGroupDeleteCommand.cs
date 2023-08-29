using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.EnumSandiBIGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBIGroups.Commands
{
    public class EnumSandiBIGroupDeleteCommand : EnumSandiBIGroupFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteEnumSandiBIGroupCommandHandler : IRequestHandler<EnumSandiBIGroupDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<EnumSandiBIGroup> _EnumSandiBIGroup;
        private readonly IMapper _mapper;

        public DeleteEnumSandiBIGroupCommandHandler(IGenericRepositoryAsync<EnumSandiBIGroup> EnumSandiBIGroup, IMapper mapper){
            _EnumSandiBIGroup = EnumSandiBIGroup;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(EnumSandiBIGroupDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _EnumSandiBIGroup.GetByIdAsync(request.BI_GROUP, "BI_GROUP");
            rFProduct.IsDeleted = true;
            await _EnumSandiBIGroup.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}