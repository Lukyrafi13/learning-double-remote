using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOHUBUNGANPERBANKANs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Commands
{
    public class RFSCOHUBUNGANPERBANKANPostValidator : AbstractValidator<RFSCOHUBUNGANPERBANKANPostCommand>
    {
        public RFSCOHUBUNGANPERBANKANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}