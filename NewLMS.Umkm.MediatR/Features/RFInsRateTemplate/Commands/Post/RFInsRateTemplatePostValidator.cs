using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFInsRateTemplates;

namespace NewLMS.UMKM.MediatR.Features.RFInsRateTemplates.Commands
{
    public class RFInsRateTemplatePostValidator : AbstractValidator<RFInsRateTemplatePostCommand>
    {
        public RFInsRateTemplatePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}