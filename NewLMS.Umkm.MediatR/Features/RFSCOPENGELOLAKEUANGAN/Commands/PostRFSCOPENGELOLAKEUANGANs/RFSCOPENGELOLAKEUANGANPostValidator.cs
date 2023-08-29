using FluentValidation;

namespace NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Commands
{
    public class RFSCOPENGELOLAKEUANGANPostValidator : AbstractValidator<RFSCOPENGELOLAKEUANGANPostCommand>
    {
        public RFSCOPENGELOLAKEUANGANPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}