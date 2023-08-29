using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Commands
{
    public class RfCompanyGroupDeleteCommand : RfCompanyGroupFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfCompanyGroupCommandHandler : IRequestHandler<RfCompanyGroupDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfCompanyGroup> _RfCompanyGroup;
        private readonly IMapper _mapper;

        public DeleteRfCompanyGroupCommandHandler(IGenericRepositoryAsync<RfCompanyGroup> RfCompanyGroup, IMapper mapper){
            _RfCompanyGroup = RfCompanyGroup;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfCompanyGroupDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RfCompanyGroup.GetByIdAsync(request.AnlCode, "AnlCode");
            rFProduct.IsDeleted = true;
            await _RfCompanyGroup.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}