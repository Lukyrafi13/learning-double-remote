using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.DeleteLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoriesDeleteCommand : LoanApplicationCreditHistoryDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteLoanApplicationCreditHistoriesCommandHandler : IRequestHandler<LoanApplicationCreditHistoriesDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCreditHistory> _loanApplicationCreditHistory;

        public DeleteLoanApplicationCreditHistoriesCommandHandler(IGenericRepositoryAsync<LoanApplicationCreditHistory> loanApplicationCreditHistory, IMapper mapper)
        {
            _loanApplicationCreditHistory = loanApplicationCreditHistory;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCreditHistoriesDeleteCommand request, CancellationToken cancellationToken)
        {
            var loanApplicationCreditHistory = await _loanApplicationCreditHistory.GetByIdAsync(request.CreditHistoryId, "CreditHistoryId");
            loanApplicationCreditHistory.IsDeleted = true;
            await _loanApplicationCreditHistory.DeleteAsync(loanApplicationCreditHistory);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);                                                                                                   
        }
    }
}
