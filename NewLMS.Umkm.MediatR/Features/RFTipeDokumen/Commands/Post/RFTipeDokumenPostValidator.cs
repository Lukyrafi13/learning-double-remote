using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFTipeDokumens;

namespace NewLMS.Umkm.MediatR.Features.RFTipeDokumens.Commands
{
    public class RFTipeDokumenPostValidator : AbstractValidator<RFTipeDokumenPostCommand>
    {
        public RFTipeDokumenPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}