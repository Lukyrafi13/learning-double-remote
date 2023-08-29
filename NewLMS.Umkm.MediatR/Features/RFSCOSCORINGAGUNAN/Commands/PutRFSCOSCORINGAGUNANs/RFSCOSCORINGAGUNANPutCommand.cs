using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOSCORINGAGUNANs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSCORINGAGUNANs.Commands
{
    public class RFSCOSCORINGAGUNANPutCommand : RFSCOSCORINGAGUNANPutRequestDto, IRequest<ServiceResponse<RFSCOSCORINGAGUNANResponseDto>>
    {
    }

    public class PutRFSCOSCORINGAGUNANCommandHandler : IRequestHandler<RFSCOSCORINGAGUNANPutCommand, ServiceResponse<RFSCOSCORINGAGUNANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> _RFSCOSCORINGAGUNAN;
        private readonly IMapper _mapper;

        public PutRFSCOSCORINGAGUNANCommandHandler(IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> RFSCOSCORINGAGUNAN, IMapper mapper){
            _RFSCOSCORINGAGUNAN = RFSCOSCORINGAGUNAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOSCORINGAGUNANResponseDto>> Handle(RFSCOSCORINGAGUNANPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOSCORINGAGUNAN = await _RFSCOSCORINGAGUNAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOSCORINGAGUNAN.SCO_CODE = request.SCO_CODE;
                existingRFSCOSCORINGAGUNAN.SCO_DESC = request.SCO_DESC;
                existingRFSCOSCORINGAGUNAN.CORE_CODE = request.CORE_CODE;
                existingRFSCOSCORINGAGUNAN.ACTIVE = request.ACTIVE;
                
                await _RFSCOSCORINGAGUNAN.UpdateAsync(existingRFSCOSCORINGAGUNAN);

                var response = _mapper.Map<RFSCOSCORINGAGUNANResponseDto>(existingRFSCOSCORINGAGUNAN);

                return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}