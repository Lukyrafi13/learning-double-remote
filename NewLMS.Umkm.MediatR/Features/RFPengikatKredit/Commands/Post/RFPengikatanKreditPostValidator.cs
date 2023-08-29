using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFPengikatanKredits;

namespace NewLMS.Umkm.MediatR.Features.RFPengikatanKredits.Commands
{
    public class RFPPengikatanKreditPostValidator : AbstractValidator<RFPengikatanKreditPostCommand>
    {
        public RFPPengikatanKreditPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}