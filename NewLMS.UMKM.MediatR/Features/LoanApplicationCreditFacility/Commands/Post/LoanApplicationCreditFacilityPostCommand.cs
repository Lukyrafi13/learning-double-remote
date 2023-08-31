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
    public class LoanApplicationCreditFacilityPostCommand : LoanApplicationCreditFacilityPostRequestDto, IRequest<ServiceResponse<LoanApplicationCreditFacilityResponseDto>>
    {

    }
    public class LoanApplicationCreditFacilityPostCommandHandler : IRequestHandler<LoanApplicationCreditFacilityPostCommand, ServiceResponse<LoanApplicationCreditFacilityResponseDto>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCreditFacility> _LoanApplicationCreditFacility;
        private readonly IMapper _mapper;

        public LoanApplicationCreditFacilityPostCommandHandler(IGenericRepositoryAsync<LoanApplicationCreditFacility> LoanApplicationCreditFacility, IMapper mapper)
        {
            _LoanApplicationCreditFacility = LoanApplicationCreditFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationCreditFacilityResponseDto>> Handle(LoanApplicationCreditFacilityPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var LoanApplicationCreditFacility = _mapper.Map<LoanApplicationCreditFacility>(request);

                var returnedLoanApplicationCreditFacility = await _LoanApplicationCreditFacility.AddAsync(LoanApplicationCreditFacility, callSave: false);

                // var response = _mapper.Map<LoanApplicationCreditFacilityResponseDto>(returnedLoanApplicationCreditFacility);
                var response = _mapper.Map<LoanApplicationCreditFacilityResponseDto>(returnedLoanApplicationCreditFacility);

                await _LoanApplicationCreditFacility.SaveChangeAsync();
                return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}