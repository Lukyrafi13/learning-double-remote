using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.PutLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoriesPutCommand : LoanApplicationCreditHistoryPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }
    
    public class PutLoanApplicationCreditHistoriesCommandHandler : IRequestHandler<LoanApplicationCreditHistoriesPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCreditHistory> _loanApplicationCreditHistory;
        private readonly IMapper _mapper;

        public PutLoanApplicationCreditHistoriesCommandHandler(IGenericRepositoryAsync<LoanApplicationCreditHistory> loanApplicationCreditHistory, IMapper mapper)
        {
            _loanApplicationCreditHistory = loanApplicationCreditHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCreditHistoriesPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Save LoanApplicationCreditHistory changes
                var loanApplicationCreditHistory = await _loanApplicationCreditHistory.GetByIdAsync(request.CreditHistoryId, "CreditHistoryId");

                loanApplicationCreditHistory.SLIKNoIdentity = request.SLIKNoIdentity;
                loanApplicationCreditHistory.DebtorName = request.DebtorName;
                loanApplicationCreditHistory.BankId = request.BankId;
                loanApplicationCreditHistory.StartDate = request.StartDate;
                loanApplicationCreditHistory.EndDate= request.EndDate;
                loanApplicationCreditHistory.EconomySector = request.EconomySector;
                loanApplicationCreditHistory.Behaviour = request.Behaviour;
                loanApplicationCreditHistory.ApplicationType = request.ApplicationType;
                loanApplicationCreditHistory.Condition = request.Condition;
                loanApplicationCreditHistory.PlafondLimit= request.PlafondLimit;
                loanApplicationCreditHistory.Interest = request.Interest;
                loanApplicationCreditHistory.Outstanding = request.Outstanding;
                loanApplicationCreditHistory.StuckDate = request.StuckDate;
                loanApplicationCreditHistory.Collectibility = request.Collectibility;
                loanApplicationCreditHistory.SLIKStatus= request.SLIKStatus;
                loanApplicationCreditHistory.LoanApplicationid= request.LoanApplicationid;
                loanApplicationCreditHistory.CreditType = request.CreditType;

                await _loanApplicationCreditHistory.UpdateAsync(loanApplicationCreditHistory);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
