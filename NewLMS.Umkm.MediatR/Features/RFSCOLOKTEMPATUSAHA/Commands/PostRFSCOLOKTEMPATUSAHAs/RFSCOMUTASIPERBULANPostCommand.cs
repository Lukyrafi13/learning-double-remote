using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOLOKTEMPATUSAHAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Commands
{
    public class RFSCOLOKTEMPATUSAHAPostCommand : RFSCOLOKTEMPATUSAHAPostRequestDto, IRequest<ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>>
    {

    }
    public class PostRFSCOLOKTEMPATUSAHACommandHandler : IRequestHandler<RFSCOLOKTEMPATUSAHAPostCommand, ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> _RFSCOLOKTEMPATUSAHA;
        private readonly IMapper _mapper;

        public PostRFSCOLOKTEMPATUSAHACommandHandler(IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> RFSCOLOKTEMPATUSAHA, IMapper mapper)
        {
            _RFSCOLOKTEMPATUSAHA = RFSCOLOKTEMPATUSAHA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>> Handle(RFSCOLOKTEMPATUSAHAPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOLOKTEMPATUSAHA = _mapper.Map<RFSCOLOKTEMPATUSAHA>(request);

                var returnedRFSCOLOKTEMPATUSAHA = await _RFSCOLOKTEMPATUSAHA.AddAsync(RFSCOLOKTEMPATUSAHA, callSave: false);

                // var response = _mapper.Map<RFSCOLOKTEMPATUSAHAResponseDto>(returnedRFSCOLOKTEMPATUSAHA);
                var response = _mapper.Map<RFSCOLOKTEMPATUSAHAResponseDto>(returnedRFSCOLOKTEMPATUSAHA);

                await _RFSCOLOKTEMPATUSAHA.SaveChangeAsync();
                return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}