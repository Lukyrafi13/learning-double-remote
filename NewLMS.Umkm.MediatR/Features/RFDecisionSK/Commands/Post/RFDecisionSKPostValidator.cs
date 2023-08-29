using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFDecisionSKs;

namespace NewLMS.Umkm.MediatR.Features.RFDecisionSKs.Commands
{
    public class RFDecisionSKPostValidator : AbstractValidator<RFDecisionSKPostCommand>
    {
        public RFDecisionSKPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}