using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOHUBUNGANPERBANKANs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Commands
{
    public class RFSCOHUBUNGANPERBANKANPostValidator : AbstractValidator<RFSCOHUBUNGANPERBANKANPostCommand>
    {
        public RFSCOHUBUNGANPERBANKANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}