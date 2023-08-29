using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFRelationSurveys;

namespace NewLMS.Umkm.MediatR.Features.RFRelationSurveys.Commands
{
    public class RFRelationSurveyPostValidator : AbstractValidator<RFRelationSurveyPostCommand>
    {
        public RFRelationSurveyPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}