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
    public class RFSCOSCORINGAGUNANPostCommand : RFSCOSCORINGAGUNANPostRequestDto, IRequest<ServiceResponse<RFSCOSCORINGAGUNANResponseDto>>
    {

    }
    public class PostRFSCOSCORINGAGUNANCommandHandler : IRequestHandler<RFSCOSCORINGAGUNANPostCommand, ServiceResponse<RFSCOSCORINGAGUNANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> _RFSCOSCORINGAGUNAN;
        private readonly IMapper _mapper;

        public PostRFSCOSCORINGAGUNANCommandHandler(IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> RFSCOSCORINGAGUNAN, IMapper mapper)
        {
            _RFSCOSCORINGAGUNAN = RFSCOSCORINGAGUNAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOSCORINGAGUNANResponseDto>> Handle(RFSCOSCORINGAGUNANPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOSCORINGAGUNAN = _mapper.Map<RFSCOSCORINGAGUNAN>(request);

                var returnedRFSCOSCORINGAGUNAN = await _RFSCOSCORINGAGUNAN.AddAsync(RFSCOSCORINGAGUNAN, callSave: false);

                // var response = _mapper.Map<RFSCOSCORINGAGUNANResponseDto>(returnedRFSCOSCORINGAGUNAN);
                var response = _mapper.Map<RFSCOSCORINGAGUNANResponseDto>(returnedRFSCOSCORINGAGUNAN);

                await _RFSCOSCORINGAGUNAN.SaveChangeAsync();
                return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}