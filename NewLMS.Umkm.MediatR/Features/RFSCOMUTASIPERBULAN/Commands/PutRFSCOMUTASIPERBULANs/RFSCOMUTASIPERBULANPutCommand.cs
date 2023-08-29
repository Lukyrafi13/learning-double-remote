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
    public class RFSCOMUTASIPERBULANPutCommand : RFSCOMUTASIPERBULANPutRequestDto, IRequest<ServiceResponse<RFSCOMUTASIPERBULANResponseDto>>
    {
    }

    public class PutRFSCOMUTASIPERBULANCommandHandler : IRequestHandler<RFSCOMUTASIPERBULANPutCommand, ServiceResponse<RFSCOMUTASIPERBULANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> _RFSCOMUTASIPERBULAN;
        private readonly IMapper _mapper;

        public PutRFSCOMUTASIPERBULANCommandHandler(IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> RFSCOMUTASIPERBULAN, IMapper mapper){
            _RFSCOMUTASIPERBULAN = RFSCOMUTASIPERBULAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOMUTASIPERBULANResponseDto>> Handle(RFSCOMUTASIPERBULANPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOMUTASIPERBULAN = await _RFSCOMUTASIPERBULAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOMUTASIPERBULAN.SCO_CODE = request.SCO_CODE;
                existingRFSCOMUTASIPERBULAN.SCO_DESC = request.SCO_DESC;
                existingRFSCOMUTASIPERBULAN.CORE_CODE = request.CORE_CODE;
                existingRFSCOMUTASIPERBULAN.ACTIVE = request.ACTIVE;
                
                await _RFSCOMUTASIPERBULAN.UpdateAsync(existingRFSCOMUTASIPERBULAN);

                var response = _mapper.Map<RFSCOMUTASIPERBULANResponseDto>(existingRFSCOMUTASIPERBULAN);

                return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}