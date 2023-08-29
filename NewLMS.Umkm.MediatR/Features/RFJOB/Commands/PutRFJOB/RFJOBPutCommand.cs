using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJOBs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJOBs.Commands
{
    public class RFJOBPutCommand : RFJOBPutRequestDto, IRequest<ServiceResponse<RFJOBResponseDto>>
    {

    }
    public class PutRFSCOCARATRANSKASICommandHandler : IRequestHandler<RFJOBPutCommand, ServiceResponse<RFJOBResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJOB> _RFJOB;
        private readonly IMapper _mapper;

        public PutRFSCOCARATRANSKASICommandHandler(IGenericRepositoryAsync<RFJOB> RFJOB, IMapper mapper)
        {
            _RFJOB = RFJOB;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJOBResponseDto>> Handle(RFJOBPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJOB = await _RFJOB.GetByIdAsync(request.JOB_CODE, "JOB_CODE");
                existingRFJOB.JOB_CODE = request.JOB_CODE;
                existingRFJOB.JOB_DESC = request.JOB_DESC;
                existingRFJOB.JOB_TYPE = request.JOB_TYPE;
                existingRFJOB.JOBSCR_TYPE = request.JOBSCR_TYPE;
                existingRFJOB.SENSITIVE = request.SENSITIVE;
                existingRFJOB.CORE_CODE = request.CORE_CODE;
                existingRFJOB.ACTIVE = request.ACTIVE;
                existingRFJOB.OTHER = request.OTHER;
                existingRFJOB.PRODUCTID = request.PRODUCTID;
                existingRFJOB.JOB_CODESIKP = request.JOB_CODESIKP;
                existingRFJOB.JOB_DESCSIKP = request.JOB_DESCSIKP;

                await _RFJOB.UpdateAsync(existingRFJOB);

                var response = _mapper.Map<RFJOBResponseDto>(existingRFJOB);


                return ServiceResponse<RFJOBResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJOBResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}