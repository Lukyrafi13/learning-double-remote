using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFApprTingkatKesuburans;

namespace NewLMS.UMKM.MediatR.Features.RFApprTingkatKesuburans.Commands
{
    public class RFApprTingkatKesuburanPostValidator : AbstractValidator<RFApprTingkatKesuburanPostCommand>
    {
        public RFApprTingkatKesuburanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}