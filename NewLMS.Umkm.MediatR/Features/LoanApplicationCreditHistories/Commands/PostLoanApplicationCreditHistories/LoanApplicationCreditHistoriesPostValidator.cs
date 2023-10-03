using FluentValidation;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.PostLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoryPostValidator : AbstractValidator<LoanApplicationCreditHistoryPostRequest>
    {
        public LoanApplicationCreditHistoryPostValidator()
        {
            RuleFor(x => x.Collectibility).NotEmpty().NotNull();
            RuleFor(x => x.LoanApplicationid).NotNull().NotEmpty();
            RuleFor(x => x.DebtorName).NotEmpty().NotNull();
            RuleFor(x => x.SLIKNoIdentity).NotEmpty().NotNull();

        }
    }
}
