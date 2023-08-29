using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLoanPurposes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLoanPurposes.Commands
{
    public class RFLoanPurposePutCommand : RFLoanPurposePutRequestDto, IRequest<ServiceResponse<RFLoanPurposeResponseDto>>
    {
    }

    public class PutRFLoanPurposeCommandHandler : IRequestHandler<RFLoanPurposePutCommand, ServiceResponse<RFLoanPurposeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private readonly IMapper _mapper;

        public PutRFLoanPurposeCommandHandler(IGenericRepositoryAsync<RFLoanPurpose> RFLoanPurpose, IMapper mapper){
            _RFLoanPurpose = RFLoanPurpose;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLoanPurposeResponseDto>> Handle(RFLoanPurposePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFLoanPurpose = await _RFLoanPurpose.GetByIdAsync(request.LP_CODE, "LP_CODE");
                existingRFLoanPurpose.LP_CODE = request.LP_CODE;
                existingRFLoanPurpose.LP_DESC = request.LP_DESC;
                existingRFLoanPurpose.CORE_CODE = request.CORE_CODE;
                existingRFLoanPurpose.Active = request.Active;
                existingRFLoanPurpose.MAXPROD = request.MAXPROD;
                
                await _RFLoanPurpose.UpdateAsync(existingRFLoanPurpose);

                var response = _mapper.Map<RFLoanPurposeResponseDto>(existingRFLoanPurpose);

                return ServiceResponse<RFLoanPurposeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLoanPurposeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}