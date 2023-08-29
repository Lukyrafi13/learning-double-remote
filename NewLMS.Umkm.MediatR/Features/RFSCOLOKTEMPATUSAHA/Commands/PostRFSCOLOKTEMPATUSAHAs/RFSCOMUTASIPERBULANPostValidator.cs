using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOLOKTEMPATUSAHAs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Commands
{
    public class RFSCOLOKTEMPATUSAHAPostValidator : AbstractValidator<RFSCOLOKTEMPATUSAHAPostCommand>
    {
        public RFSCOLOKTEMPATUSAHAPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}