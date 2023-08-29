using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFLoanPurposes;

namespace NewLMS.UMKM.MediatR.Features.RFLoanPurposes.Commands
{
    public class RFLoanPurposePostValidator : AbstractValidator<RFLoanPurposePostCommand>
    {
        public RFLoanPurposePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}