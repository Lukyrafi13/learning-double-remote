using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFConditions;

namespace NewLMS.UMKM.MediatR.Features.RFConditions.Commands
{
    public class RFConditionPostValidator : AbstractValidator<RFConditionPostCommand>
    {
        public RFConditionPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}