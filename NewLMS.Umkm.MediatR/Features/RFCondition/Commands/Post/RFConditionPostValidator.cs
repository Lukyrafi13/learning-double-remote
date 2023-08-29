using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFConditions;

namespace NewLMS.Umkm.MediatR.Features.RFConditions.Commands
{
    public class RFConditionPostValidator : AbstractValidator<RFConditionPostCommand>
    {
        public RFConditionPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}