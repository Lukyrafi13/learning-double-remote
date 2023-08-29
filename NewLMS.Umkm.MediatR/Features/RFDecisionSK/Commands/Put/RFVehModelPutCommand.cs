using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDecisionSKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDecisionSKs.Commands
{
    public class RFDecisionSKPutCommand : RFDecisionSKPutRequestDto, IRequest<ServiceResponse<RFDecisionSKResponseDto>>
    {
    }

    public class PutRFDecisionSKCommandHandler : IRequestHandler<RFDecisionSKPutCommand, ServiceResponse<RFDecisionSKResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFDecisionSK> _RFDecisionSK;
        private readonly IMapper _mapper;

        public PutRFDecisionSKCommandHandler(IGenericRepositoryAsync<RFDecisionSK> RFDecisionSK, IMapper mapper){
            _RFDecisionSK = RFDecisionSK;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDecisionSKResponseDto>> Handle(RFDecisionSKPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFDecisionSK = await _RFDecisionSK.GetByIdAsync(request.DEC_CODE, "DEC_CODE");
                existingRFDecisionSK.DEC_CODE = request.DEC_CODE;
                existingRFDecisionSK.DEC_DESC = request.DEC_DESC;
                existingRFDecisionSK.CORE_CODE = request.CORE_CODE;
                existingRFDecisionSK.ACTIVE = request.ACTIVE;
                
                await _RFDecisionSK.UpdateAsync(existingRFDecisionSK);

                var response = _mapper.Map<RFDecisionSKResponseDto>(existingRFDecisionSK);

                return ServiceResponse<RFDecisionSKResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDecisionSKResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}