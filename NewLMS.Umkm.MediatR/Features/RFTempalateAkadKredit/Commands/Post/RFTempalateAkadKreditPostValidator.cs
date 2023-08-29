using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFTempalateAkadKredits;

namespace NewLMS.UMKM.MediatR.Features.RFTempalateAkadKredits.Commands
{
    public class RFTempalateAkadKreditPostValidator : AbstractValidator<RFTempalateAkadKreditPostCommand>
    {
        public RFTempalateAkadKreditPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}