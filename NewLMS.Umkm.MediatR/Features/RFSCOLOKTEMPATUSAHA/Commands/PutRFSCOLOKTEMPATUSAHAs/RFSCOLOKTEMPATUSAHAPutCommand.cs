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
    public class RFSCOLOKTEMPATUSAHAPutCommand : RFSCOLOKTEMPATUSAHAPutRequestDto, IRequest<ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>>
    {
    }

    public class PutRFSCOLOKTEMPATUSAHACommandHandler : IRequestHandler<RFSCOLOKTEMPATUSAHAPutCommand, ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> _RFSCOLOKTEMPATUSAHA;
        private readonly IMapper _mapper;

        public PutRFSCOLOKTEMPATUSAHACommandHandler(IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> RFSCOLOKTEMPATUSAHA, IMapper mapper)
        {
            _RFSCOLOKTEMPATUSAHA = RFSCOLOKTEMPATUSAHA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>> Handle(RFSCOLOKTEMPATUSAHAPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOLOKTEMPATUSAHA = await _RFSCOLOKTEMPATUSAHA.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOLOKTEMPATUSAHA.SCO_CODE = request.SCO_CODE;
                existingRFSCOLOKTEMPATUSAHA.SCO_DESC = request.SCO_DESC;
                existingRFSCOLOKTEMPATUSAHA.CORE_CODE = request.CORE_CODE;
                existingRFSCOLOKTEMPATUSAHA.ACTIVE = request.ACTIVE;

                await _RFSCOLOKTEMPATUSAHA.UpdateAsync(existingRFSCOLOKTEMPATUSAHA);

                var response = _mapper.Map<RFSCOLOKTEMPATUSAHAResponseDto>(existingRFSCOLOKTEMPATUSAHA);

                return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}