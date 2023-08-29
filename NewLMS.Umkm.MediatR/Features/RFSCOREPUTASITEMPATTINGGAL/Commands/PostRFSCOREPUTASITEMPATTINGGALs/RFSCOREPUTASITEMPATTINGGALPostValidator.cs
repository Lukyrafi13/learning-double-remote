using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Commands
{
    public class RFSCOREPUTASITEMPATTINGGALPostValidator : AbstractValidator<RFSCOREPUTASITEMPATTINGGALPostCommand>
    {
        public RFSCOREPUTASITEMPATTINGGALPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}