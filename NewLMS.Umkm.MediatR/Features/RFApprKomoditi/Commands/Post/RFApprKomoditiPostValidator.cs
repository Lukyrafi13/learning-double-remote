using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFApprKomoditis;

namespace NewLMS.UMKM.MediatR.Features.RFApprKomoditis.Commands
{
    public class RFApprKomoditiPostValidator : AbstractValidator<RFApprKomoditiPostCommand>
    {
        public RFApprKomoditiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}