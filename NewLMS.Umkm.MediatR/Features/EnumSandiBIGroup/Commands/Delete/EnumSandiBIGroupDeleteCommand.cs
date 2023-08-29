using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.EnumSandiBIGroups;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBIGroups.Commands
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