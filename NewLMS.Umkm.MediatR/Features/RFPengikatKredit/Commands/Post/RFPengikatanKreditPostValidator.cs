using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFPengikatanKredits;

namespace NewLMS.UMKM.MediatR.Features.RFPengikatanKredits.Commands
{
    public class RFPPengikatanKreditPostValidator : AbstractValidator<RFPengikatanKreditPostCommand>
    {
        public RFPPengikatanKreditPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}