using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFApprTingkatKesuburans;

namespace NewLMS.Umkm.MediatR.Features.RFApprTingkatKesuburans.Commands
{
    public class RFApprTingkatKesuburanPostValidator : AbstractValidator<RFApprTingkatKesuburanPostCommand>
    {
        public RFApprTingkatKesuburanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}