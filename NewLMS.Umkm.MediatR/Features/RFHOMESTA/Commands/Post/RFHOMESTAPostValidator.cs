using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFHOMESTAs;

namespace NewLMS.UMKM.MediatR.Features.RFHOMESTAs.Commands
{
    public class RFHOMESTAPostValidator : AbstractValidator<RFHOMESTAPostCommand>
    {
        public RFHOMESTAPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}