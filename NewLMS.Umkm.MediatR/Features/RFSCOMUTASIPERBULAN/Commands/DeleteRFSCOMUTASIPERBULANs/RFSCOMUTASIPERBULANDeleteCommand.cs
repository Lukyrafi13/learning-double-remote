using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOMUTASIPERBULANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOMUTASIPERBULANs.Commands
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