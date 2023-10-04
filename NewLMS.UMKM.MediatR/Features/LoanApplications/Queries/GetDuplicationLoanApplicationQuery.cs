using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationDuplication;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplications.Queries.GetDuplicationLoanApplication
{
    /// <summary>
    /// Handler to find if this application is duplicate in core, loan, or dwh
    /// </summary>
    public class GetDuplicationLoanApplicationQuery : IRequest<ServiceResponse<LoanApplicationDuplicationResponse>>
    {
        public Guid LoanApplicationGuid { get; set; }
    }

    public class GetDuplicateOrNotLocalLoadApplicationQueryHandler : IRequestHandler<GetDuplicationLoanApplicationQuery, ServiceResponse<LoanApplicationDuplicationResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationDuplication> _loanApplicationDuplication;
        private readonly IMapper _mapper;


        public GetDuplicateOrNotLocalLoadApplicationQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IGenericRepositoryAsync<LoanApplicationDuplication> loanApplicationDuplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _loanApplicationDuplication = loanApplicationDuplication;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<LoanApplicationDuplicationResponse>> Handle(GetDuplicationLoanApplicationQuery request, CancellationToken cancellationToken)
        {

            var loanApplication = await _loanApplication.GetByIdAsync(request.LoanApplicationGuid, "Id");

            if (loanApplication == null)
                return ServiceResponse<LoanApplicationDuplicationResponse>.Return404("LoanApplicationId Not Found");

            var IsDuplicateLMS = await _loanApplicationDuplication.GetListByPredicate(x => x.SearchDesc.StartsWith("Internal") && x.LoanApplicationGuid == request.LoanApplicationGuid);
            var IsDuplicateDWH = await _loanApplicationDuplication.GetListByPredicate(x => x.SearchDesc.StartsWith("DWH") && x.LoanApplicationGuid == request.LoanApplicationGuid);
            var IsDuplicateDHN = await _loanApplicationDuplication.GetListByPredicate(x => x.SearchDesc.StartsWith("BLACKLIST") && x.LoanApplicationGuid == request.LoanApplicationGuid);

            var duplicateInLMS = IsDuplicateLMS.Count > 0;
            var duplicateInDWH = IsDuplicateDWH.Count > 0;
            var duplicateInDHN = IsDuplicateDHN.Count > 0;

            var SearchResultLMS = _mapper.Map<List<LoanApplicationDetailResponse>>(IsDuplicateLMS);
            var SearchResultDWH = _mapper.Map<List<LoanApplicationDetailResponse>>(IsDuplicateDWH);
            var SearchResultDHN = _mapper.Map<List<LoanApplicationDetailResponse>>(IsDuplicateDHN);

            LoanApplicationDuplicationResponse duplicateLoanApplication = new()
            {
                Internal = new LoanApplicationDuplicateLMSResponse
                {
                    IsDuplicate = duplicateInLMS,
                    MSearch = SearchResultLMS
                },
                Core = new LoanApplicationDuplicateLMSResponse
                {
                    IsDuplicate = duplicateInDWH,
                    MSearch = SearchResultDWH
                },
                DHN = new LoanApplicationDuplicateLMSResponse
                {
                    IsDuplicate = duplicateInDHN,
                    MSearch = SearchResultDHN
                }
            };
            return ServiceResponse<LoanApplicationDuplicationResponse>.ReturnResultWith200(duplicateLoanApplication);
        }
    }
}