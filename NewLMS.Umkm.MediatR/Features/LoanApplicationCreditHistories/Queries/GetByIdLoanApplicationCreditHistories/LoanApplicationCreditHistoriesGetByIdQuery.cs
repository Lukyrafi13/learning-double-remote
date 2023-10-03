using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Queries.GetByIdLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoriesGetByIdQuery : IRequest<ServiceResponse<LoanApplicationCreditHistoryResponse>>
    {
        public Guid CreditHistoryId { get; set; }
    }

    public class GetByIdLoanApplicationCreditHistoryQueryHandler : IRequestHandler<LoanApplicationCreditHistoriesGetByIdQuery, ServiceResponse<LoanApplicationCreditHistoryResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationCreditHistory> _loanApplicationCreditHistory;
        private readonly IMapper _mapper;

        public GetByIdLoanApplicationCreditHistoryQueryHandler(IGenericRepositoryAsync<LoanApplicationCreditHistory> loanApplicationCreditHistory, IMapper mapper)
        {
            _loanApplicationCreditHistory = loanApplicationCreditHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationCreditHistoryResponse>> Handle(LoanApplicationCreditHistoriesGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "RfBank",
                    "RfSandiBIEconomySectorClass",
                    "RfSandiBIBehaviourClass",
                    "RfSandiBIApplicationTypeClass",
                    "RfSandiBICollectibilityClass",
                    "RfCondition",
                    "RfCreditType"
                };
                var data = await _loanApplicationCreditHistory.GetByIdAsync(request.CreditHistoryId, "CreditHistoryId", includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationCreditHistoryResponse>.Return404("Data LoanApplicationCreditHistory not found");
                var dataVm = _mapper.Map<LoanApplicationCreditHistoryResponse>(data);
                return ServiceResponse<LoanApplicationCreditHistoryResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<LoanApplicationCreditHistoryResponse>.ReturnException(ex);
            }

        }
    }
}
