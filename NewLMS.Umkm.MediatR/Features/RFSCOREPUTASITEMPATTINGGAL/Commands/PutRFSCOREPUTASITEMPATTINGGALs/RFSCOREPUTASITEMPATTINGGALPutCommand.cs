using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Commands
{
    public class RFSCOREPUTASITEMPATTINGGALPutCommand : RFSCOREPUTASITEMPATTINGGALPutRequestDto, IRequest<ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>>
    {
    }

    public class PutRFSCOREPUTASITEMPATTINGGALCommandHandler : IRequestHandler<RFSCOREPUTASITEMPATTINGGALPutCommand, ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> _rfScoReputasiTempatTinggal;
        private readonly IMapper _mapper;

        public PutRFSCOREPUTASITEMPATTINGGALCommandHandler(IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> rfScoReputasiTempatTinggal, IMapper mapper){
            _rfScoReputasiTempatTinggal = rfScoReputasiTempatTinggal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>> Handle(RFSCOREPUTASITEMPATTINGGALPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOREPUTASITEMPATTINGGAL = await _rfScoReputasiTempatTinggal.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOREPUTASITEMPATTINGGAL.SCO_CODE = request.SCO_CODE;
                existingRFSCOREPUTASITEMPATTINGGAL.SCO_DESC = request.SCO_DESC;
                existingRFSCOREPUTASITEMPATTINGGAL.CORE_CODE = request.CORE_CODE;
                existingRFSCOREPUTASITEMPATTINGGAL.ACTIVE = request.ACTIVE;
                
                await _rfScoReputasiTempatTinggal.UpdateAsync(existingRFSCOREPUTASITEMPATTINGGAL);

                var response = _mapper.Map<RFSCOREPUTASITEMPATTINGGALResponseDto>(existingRFSCOREPUTASITEMPATTINGGAL);

                return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}