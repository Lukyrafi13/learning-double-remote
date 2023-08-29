using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFInsRateTemplates;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateTemplates.Commands
{
    public class RFInsRateTemplatePostValidator : AbstractValidator<RFInsRateTemplatePostCommand>
    {
        public RFInsRateTemplatePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}