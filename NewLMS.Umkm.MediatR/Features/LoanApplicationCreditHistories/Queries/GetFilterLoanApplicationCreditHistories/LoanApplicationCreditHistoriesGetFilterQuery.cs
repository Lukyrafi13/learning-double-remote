using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Queries.GetFilterLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoryGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationCreditHistoryResponse>>>
    {
    }

    public class GetFilterLoanApplicationCreditHistoryQueryHandler : IRequestHandler<LoanApplicationCreditHistoryGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationCreditHistoryResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationCreditHistory> _loanApplicationCreditHistory;
        private readonly IMapper _mapper;

        public GetFilterLoanApplicationCreditHistoryQueryHandler(IGenericRepositoryAsync<LoanApplicationCreditHistory> loanApplicationCreditHistory, IMapper mapper)
        {
            _loanApplicationCreditHistory = loanApplicationCreditHistory;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationCreditHistoryResponse>>> Handle(LoanApplicationCreditHistoryGetFilterQuery request, CancellationToken cancellationToken)
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
            var data = await _loanApplicationCreditHistory.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<LoanApplicationCreditHistoryResponse>>(data.Results);
            return new PagedResponse<IEnumerable<LoanApplicationCreditHistoryResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
