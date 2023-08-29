using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFDecisionSKs;

namespace NewLMS.UMKM.MediatR.Features.RFDecisionSKs.Commands
{
    public class RFDecisionSKPostValidator : AbstractValidator<RFDecisionSKPostCommand>
    {
        public RFDecisionSKPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}