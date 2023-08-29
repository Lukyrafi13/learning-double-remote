using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFTipeDokumens;

namespace NewLMS.UMKM.MediatR.Features.RFTipeDokumens.Commands
{
    public class RFTipeDokumenPostValidator : AbstractValidator<RFTipeDokumenPostCommand>
    {
        public RFTipeDokumenPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}