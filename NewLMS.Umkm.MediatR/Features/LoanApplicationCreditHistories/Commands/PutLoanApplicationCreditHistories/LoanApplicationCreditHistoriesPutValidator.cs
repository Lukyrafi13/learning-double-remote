using FluentValidation;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.PutLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoriesPutValidator : AbstractValidator<LoanApplicationCreditHistoriesPutCommand>
    {
        public LoanApplicationCreditHistoriesPutValidator()
        {
            RuleFor(x => x.CreditHistoryId).NotEmpty();
            RuleFor(x => x.Collectibility).NotEmpty().NotNull();
            RuleFor(x => x.LoanApplicationid).NotNull().NotEmpty();
            RuleFor(x => x.DebtorName).NotEmpty().NotNull();
            RuleFor(x => x.SLIKNoIdentity).NotEmpty().NotNull();

        }
    }
}
