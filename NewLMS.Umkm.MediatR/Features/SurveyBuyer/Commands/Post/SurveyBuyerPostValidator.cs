using FluentValidation;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;

namespace NewLMS.Umkm.MediatR.Features.SurveyBuyers.Commands
{
    public class SurveyBuyerPostValidator : AbstractValidator<SurveyBuyerPostCommand>
    {
        public SurveyBuyerPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}