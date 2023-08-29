using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOSALDOREKRATAs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOSALDOREKRATAs.Commands
{
    public class RFSCOSALDOREKRATAPostValidator : AbstractValidator<RFSCOSALDOREKRATAPostCommand>
    {
        public RFSCOSALDOREKRATAPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}