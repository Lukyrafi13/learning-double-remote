using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFRelationSurveys;

namespace NewLMS.UMKM.MediatR.Features.RFRelationSurveys.Commands
{
    public class RFRelationSurveyPostValidator : AbstractValidator<RFRelationSurveyPostCommand>
    {
        public RFRelationSurveyPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}