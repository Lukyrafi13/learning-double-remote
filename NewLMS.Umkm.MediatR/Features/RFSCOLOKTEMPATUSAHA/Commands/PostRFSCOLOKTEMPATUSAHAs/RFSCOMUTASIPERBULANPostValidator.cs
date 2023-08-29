using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOLOKTEMPATUSAHAs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Commands
{
    public class RFSCOLOKTEMPATUSAHAPostValidator : AbstractValidator<RFSCOLOKTEMPATUSAHAPostCommand>
    {
        public RFSCOLOKTEMPATUSAHAPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}