using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFCaraPengikatans;

namespace NewLMS.Umkm.MediatR.Features.RFCaraPengikatans.Commands
{
    public class RFCaraPengikatanPostValidator : AbstractValidator<RFCaraPengikatanPostCommand>
    {
        public RFCaraPengikatanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}