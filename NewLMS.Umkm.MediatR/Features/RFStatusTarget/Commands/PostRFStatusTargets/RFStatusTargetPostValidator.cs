using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFStatusTargets;

namespace NewLMS.Umkm.MediatR.Features.RFStatusTargets.Commands
{
    public class RFStatusTargetPostValidator : AbstractValidator<RFStatusTargetPostCommand>
    {
        public RFStatusTargetPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}