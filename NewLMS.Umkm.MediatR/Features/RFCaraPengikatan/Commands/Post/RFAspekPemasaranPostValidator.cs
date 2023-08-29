using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFCaraPengikatans;

namespace NewLMS.UMKM.MediatR.Features.RFCaraPengikatans.Commands
{
    public class RFCaraPengikatanPostValidator : AbstractValidator<RFCaraPengikatanPostCommand>
    {
        public RFCaraPengikatanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}