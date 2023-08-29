using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOSCORINGAGUNANs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSCORINGAGUNANs.Commands
{
    public class RFSCOSCORINGAGUNANPostValidator : AbstractValidator<RFSCOSCORINGAGUNANPostCommand>
    {
        public RFSCOSCORINGAGUNANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}