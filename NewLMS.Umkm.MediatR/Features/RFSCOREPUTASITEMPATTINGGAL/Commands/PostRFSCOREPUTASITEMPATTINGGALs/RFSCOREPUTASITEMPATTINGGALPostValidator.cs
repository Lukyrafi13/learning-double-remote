using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Commands
{
    public class RFSCOREPUTASITEMPATTINGGALPostValidator : AbstractValidator<RFSCOREPUTASITEMPATTINGGALPostCommand>
    {
        public RFSCOREPUTASITEMPATTINGGALPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}