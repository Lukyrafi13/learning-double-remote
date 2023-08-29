using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfBranches;

namespace NewLMS.UMKM.MediatR.Features.RfBranches.Commands
{
    public class RFBranchPostValidator : AbstractValidator<RfBranchPostCommand>
    {
        public RFBranchPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}