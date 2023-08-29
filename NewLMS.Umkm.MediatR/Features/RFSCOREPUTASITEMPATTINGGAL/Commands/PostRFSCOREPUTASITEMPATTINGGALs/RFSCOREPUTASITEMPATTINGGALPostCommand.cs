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
    public class RFSCOREPUTASITEMPATTINGGALPostCommand : RFSCOREPUTASITEMPATTINGGALPostRequestDto, IRequest<ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>>
    {

    }
    public class PostRFSCOREPUTASITEMPATTINGGALCommandHandler : IRequestHandler<RFSCOREPUTASITEMPATTINGGALPostCommand, ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> _rfScoReputasiTempatTinggal;
        private readonly IMapper _mapper;

        public PostRFSCOREPUTASITEMPATTINGGALCommandHandler(IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> rfScoReputasiTempatTinggal, IMapper mapper)
        {
            _rfScoReputasiTempatTinggal = rfScoReputasiTempatTinggal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>> Handle(RFSCOREPUTASITEMPATTINGGALPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfScoReputasiTempatTinggal = _mapper.Map<RFSCOREPUTASITEMPATTINGGAL>(request);

                var returnedRfProduct = await _rfScoReputasiTempatTinggal.AddAsync(rfScoReputasiTempatTinggal, callSave: false);

                // var response = _mapper.Map<RFSCOREPUTASITEMPATTINGGALResponseDto>(returnedRfProduct);
                var response = _mapper.Map<RFSCOREPUTASITEMPATTINGGALResponseDto>(returnedRfProduct);

                await _rfScoReputasiTempatTinggal.SaveChangeAsync();
                return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}