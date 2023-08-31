using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCreditFacilities.Commands
{
    public class LoanApplicationCreditFacilityPutCommand : LoanApplicationCreditFacilityPutRequestDto, IRequest<ServiceResponse<LoanApplicationCreditFacilityResponseDto>>
    {
    }

    public class PutLoanApplicationCreditFacilityCommandHandler : IRequestHandler<LoanApplicationCreditFacilityPutCommand, ServiceResponse<LoanApplicationCreditFacilityResponseDto>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCreditFacility> _LoanApplicationCreditFacility;
        private readonly IMapper _mapper;

        public PutLoanApplicationCreditFacilityCommandHandler(IGenericRepositoryAsync<LoanApplicationCreditFacility> LoanApplicationCreditFacility, IMapper mapper)
        {
            _LoanApplicationCreditFacility = LoanApplicationCreditFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationCreditFacilityResponseDto>> Handle(LoanApplicationCreditFacilityPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingLoanApplicationCreditFacility = await _LoanApplicationCreditFacility.GetByIdAsync(request.Id, "Id");
                
                existingLoanApplicationCreditFacility = _mapper.Map<LoanApplicationCreditFacilityPutRequestDto, LoanApplicationCreditFacility>(request, existingLoanApplicationCreditFacility);

                await _LoanApplicationCreditFacility.UpdateAsync(existingLoanApplicationCreditFacility);

                var response = _mapper.Map<LoanApplicationCreditFacilityResponseDto>(existingLoanApplicationCreditFacility);

                return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}