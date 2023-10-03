using FluentValidation;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.DeleteLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoriesDeleteValidator : AbstractValidator<LoanApplicationCreditHistoryDeleteRequest>
    {
        public LoanApplicationCreditHistoriesDeleteValidator()
        {
            RuleFor(c => c.CreditHistoryId).NotEmpty().WithMessage("CreditHistoryId is required");
        }
    }
}
