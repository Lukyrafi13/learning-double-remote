using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Konsumer.MediatR.Features.LoanApplicationCreditHistories.Queries.GetWorstCollectabilityApplicationCreditHistories
{
    public class GetWorstCollectabilityQuery : IRequest<ServiceResponse<LoanApplicationCreditHistoryResponse>>
    {
        public Guid LoanApplicationId { get; set; }
    }

    public class GetWorstCollectabilityLoanApplicationCreditHistoryQueryHandler : IRequestHandler<GetWorstCollectabilityQuery, ServiceResponse<LoanApplicationCreditHistoryResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationCreditHistory> _loanApplicationCreditHistory;
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetWorstCollectabilityLoanApplicationCreditHistoryQueryHandler(IGenericRepositoryAsync<LoanApplicationCreditHistory> loanApplicationCreditHistory, IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplicationCreditHistory = loanApplicationCreditHistory;
            _mapper = mapper;
            _loanApplication = loanApplication;
        }

        public async Task<ServiceResponse<LoanApplicationCreditHistoryResponse>> Handle(GetWorstCollectabilityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "LoanApplicationCreditHistories.RfBank",
                    "LoanApplicationCreditHistories.RfSandiBIEconomySectorClass",
                    "LoanApplicationCreditHistories.RfSandiBIApplicationTypeClass",
                    "LoanApplicationCreditHistories.RfSandiBIBehaviourClass",
                    "LoanApplicationCreditHistories.RfSandiBICollectibilityClass",
                    "LoanApplicationCreditHistories.RfCondition",
                    "LoanApplicationCreditHistories.RfCreditType",
                    "Debtor",
                };

                var loanApplication = await _loanApplication.GetByIdAsync(request.LoanApplicationId, "Id", includes);
                if (loanApplication == null)
                    return ServiceResponse<LoanApplicationCreditHistoryResponse>.Return404("Data loanApplication not found");

                List<string> ExcludeCollectability = new(new string[] { "0", "1" });

                var creditHistoryDebitur = loanApplication.LoanApplicationCreditHistories
                                        .Where(x => x.LoanApplicationid == loanApplication.Id && x.SLIKNoIdentity == loanApplication.Debtor?.NoIdentity && !ExcludeCollectability.Contains(x?.RfSandiBICollectibilityClass?.BICode))
                                        .OrderByDescending(x => x?.RfSandiBICollectibilityClass?.BICode)
                                        .FirstOrDefault();


                var dataVm = _mapper.Map<LoanApplicationCreditHistoryResponse>(creditHistoryDebitur);
                return ServiceResponse<LoanApplicationCreditHistoryResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<LoanApplicationCreditHistoryResponse>.ReturnException(ex);
            }

        }
    }
}
