using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFApprKomoditis;

namespace NewLMS.Umkm.MediatR.Features.RFApprKomoditis.Commands
{
    public class RFApprKomoditiPostValidator : AbstractValidator<RFApprKomoditiPostCommand>
    {
        public RFApprKomoditiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}