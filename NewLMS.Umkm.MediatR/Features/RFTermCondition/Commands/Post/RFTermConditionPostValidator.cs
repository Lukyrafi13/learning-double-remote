using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFTermConditions;

namespace NewLMS.Umkm.MediatR.Features.RFTermConditions.Commands
{
    public class RFTermConditionPostValidator : AbstractValidator<RFTermConditionPostCommand>
    {
        public RFTermConditionPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}