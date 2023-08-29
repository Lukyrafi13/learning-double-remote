using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFTermConditions;

namespace NewLMS.UMKM.MediatR.Features.RFTermConditions.Commands
{
    public class RFTermConditionPostValidator : AbstractValidator<RFTermConditionPostCommand>
    {
        public RFTermConditionPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}