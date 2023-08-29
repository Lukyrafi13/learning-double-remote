using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOMUTASIPERBULANs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOMUTASIPERBULANs.Commands
{
    public class RFSCOMUTASIPERBULANPostValidator : AbstractValidator<RFSCOMUTASIPERBULANPostCommand>
    {
        public RFSCOMUTASIPERBULANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}