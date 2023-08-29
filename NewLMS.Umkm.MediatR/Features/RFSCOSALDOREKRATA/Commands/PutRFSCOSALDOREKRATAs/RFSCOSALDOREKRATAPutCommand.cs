using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Commands
{
    public class RFSCOSALDOREKRATAPutCommand : RFSCOSALDOREKRATAPutRequestDto, IRequest<ServiceResponse<RFSCOSALDOREKRATAResponseDto>>
    {
    }

    public class PutRFSCOSALDOREKRATACommandHandler : IRequestHandler<RFSCOSALDOREKRATAPutCommand, ServiceResponse<RFSCOSALDOREKRATAResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOSALDOREKRATA> _RFSCOSALDOREKRATA;
        private readonly IMapper _mapper;

        public PutRFSCOSALDOREKRATACommandHandler(IGenericRepositoryAsync<RFSCOSALDOREKRATA> RFSCOSALDOREKRATA, IMapper mapper){
            _RFSCOSALDOREKRATA = RFSCOSALDOREKRATA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOSALDOREKRATAResponseDto>> Handle(RFSCOSALDOREKRATAPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOSALDOREKRATA = await _RFSCOSALDOREKRATA.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOSALDOREKRATA.SCO_CODE = request.SCO_CODE;
                existingRFSCOSALDOREKRATA.SCO_DESC = request.SCO_DESC;
                existingRFSCOSALDOREKRATA.CORE_CODE = request.CORE_CODE;
                existingRFSCOSALDOREKRATA.ACTIVE = request.ACTIVE;
                
                await _RFSCOSALDOREKRATA.UpdateAsync(existingRFSCOSALDOREKRATA);

                var response = _mapper.Map<RFSCOSALDOREKRATAResponseDto>(existingRFSCOSALDOREKRATA);

                return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}