using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFTempalateAkadKredits;

namespace NewLMS.Umkm.MediatR.Features.RFTempalateAkadKredits.Commands
{
    public class RFTempalateAkadKreditPostValidator : AbstractValidator<RFTempalateAkadKreditPostCommand>
    {
        public RFTempalateAkadKreditPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}