using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTingkatKesuburans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTingkatKesuburans.Commands
{
    public class RFApprTingkatKesuburanPutCommand : RFApprTingkatKesuburanPutRequestDto, IRequest<ServiceResponse<RFApprTingkatKesuburanResponseDto>>
    {
    }

    public class PutRFApprTingkatKesuburanCommandHandler : IRequestHandler<RFApprTingkatKesuburanPutCommand, ServiceResponse<RFApprTingkatKesuburanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprTingkatKesuburan> _RFApprTingkatKesuburan;
        private readonly IMapper _mapper;

        public PutRFApprTingkatKesuburanCommandHandler(IGenericRepositoryAsync<RFApprTingkatKesuburan> RFApprTingkatKesuburan, IMapper mapper)
        {
            _RFApprTingkatKesuburan = RFApprTingkatKesuburan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprTingkatKesuburanResponseDto>> Handle(RFApprTingkatKesuburanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFApprTingkatKesuburan = await _RFApprTingkatKesuburan.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                existingRFApprTingkatKesuburan.APPR_CODE = request.APPR_CODE;
                existingRFApprTingkatKesuburan.APPR_DESC = request.APPR_DESC;
                existingRFApprTingkatKesuburan.CORE_CODE = request.CORE_CODE;
                existingRFApprTingkatKesuburan.ACTIVE = request.ACTIVE;

                await _RFApprTingkatKesuburan.UpdateAsync(existingRFApprTingkatKesuburan);

                var response = _mapper.Map<RFApprTingkatKesuburanResponseDto>(existingRFApprTingkatKesuburan);

                return ServiceResponse<RFApprTingkatKesuburanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTingkatKesuburanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}