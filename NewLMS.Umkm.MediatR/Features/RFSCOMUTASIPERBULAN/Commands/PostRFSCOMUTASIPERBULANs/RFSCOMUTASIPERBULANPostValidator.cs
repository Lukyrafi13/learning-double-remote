using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOMUTASIPERBULANs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOMUTASIPERBULANs.Commands
{
    public class RFSCOMUTASIPERBULANPostValidator : AbstractValidator<RFSCOMUTASIPERBULANPostCommand>
    {
        public RFSCOMUTASIPERBULANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}