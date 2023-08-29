using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOMUTASIPERBULANs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOMUTASIPERBULANs.Commands
{
    public class RFSCOMUTASIPERBULANDeleteCommand : RFSCOMUTASIPERBULANFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCOMUTASIPERBULANCommandHandler : IRequestHandler<RFSCOMUTASIPERBULANDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> _RFSCOMUTASIPERBULAN;
        private readonly IMapper _mapper;

        public DeleteRFSCOMUTASIPERBULANCommandHandler(IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> RFSCOMUTASIPERBULAN, IMapper mapper){
            _RFSCOMUTASIPERBULAN = RFSCOMUTASIPERBULAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOMUTASIPERBULANDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOMUTASIPERBULAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOMUTASIPERBULAN.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}