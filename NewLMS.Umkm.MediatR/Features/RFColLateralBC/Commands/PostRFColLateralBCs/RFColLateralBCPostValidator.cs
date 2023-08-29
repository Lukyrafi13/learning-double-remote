using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFColLateralBCs;

namespace NewLMS.Umkm.MediatR.Features.RFColLateralBCs.Commands
{
    public class RFColLateralBCPostValidator : AbstractValidator<RFColLateralBCPostCommand>
    {
        public RFColLateralBCPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}