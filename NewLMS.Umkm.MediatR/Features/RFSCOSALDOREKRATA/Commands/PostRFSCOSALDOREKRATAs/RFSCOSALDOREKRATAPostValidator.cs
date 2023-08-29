using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Commands
{
    public class RFSCOSALDOREKRATAPostValidator : AbstractValidator<RFSCOSALDOREKRATAPostCommand>
    {
        public RFSCOSALDOREKRATAPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}