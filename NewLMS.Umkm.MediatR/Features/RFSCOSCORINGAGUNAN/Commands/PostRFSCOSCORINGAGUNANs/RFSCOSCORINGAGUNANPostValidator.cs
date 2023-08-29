using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOSCORINGAGUNANs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOSCORINGAGUNANs.Commands
{
    public class RFSCOSCORINGAGUNANPostValidator : AbstractValidator<RFSCOSCORINGAGUNANPostCommand>
    {
        public RFSCOSCORINGAGUNANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}