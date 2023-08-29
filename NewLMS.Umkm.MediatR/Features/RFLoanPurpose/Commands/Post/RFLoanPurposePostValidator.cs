using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFLoanPurposes;

namespace NewLMS.Umkm.MediatR.Features.RFLoanPurposes.Commands
{
    public class RFLoanPurposePostValidator : AbstractValidator<RFLoanPurposePostCommand>
    {
        public RFLoanPurposePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}