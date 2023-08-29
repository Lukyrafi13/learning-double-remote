using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFBentukLahans;

namespace NewLMS.Umkm.MediatR.Features.RFBentukLahans.Commands
{
    public class RFBentukLahanPostValidator : AbstractValidator<RFBentukLahanPostCommand>
    {
        public RFBentukLahanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}