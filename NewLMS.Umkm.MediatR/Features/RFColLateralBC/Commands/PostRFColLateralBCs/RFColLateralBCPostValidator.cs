using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFColLateralBCs;

namespace NewLMS.UMKM.MediatR.Features.RFColLateralBCs.Commands
{
    public class RFColLateralBCPostValidator : AbstractValidator<RFColLateralBCPostCommand>
    {
        public RFColLateralBCPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}