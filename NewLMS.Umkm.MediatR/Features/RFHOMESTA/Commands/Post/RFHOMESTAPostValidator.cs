using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFHOMESTAs;

namespace NewLMS.Umkm.MediatR.Features.RFHOMESTAs.Commands
{
    public class RFHOMESTAPostValidator : AbstractValidator<RFHOMESTAPostCommand>
    {
        public RFHOMESTAPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}