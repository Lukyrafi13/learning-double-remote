using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFBentukLahans;

namespace NewLMS.UMKM.MediatR.Features.RFBentukLahans.Commands
{
    public class RFBentukLahanPostValidator : AbstractValidator<RFBentukLahanPostCommand>
    {
        public RFBentukLahanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}