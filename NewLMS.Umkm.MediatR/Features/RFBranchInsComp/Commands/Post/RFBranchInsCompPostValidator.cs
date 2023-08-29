using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFBranchInsComps;

namespace NewLMS.UMKM.MediatR.Features.RFBranchInsComps.Commands
{
    public class RFBranchInsCompPostValidator : AbstractValidator<RFBranchInsCompPostCommand>
    {
        public RFBranchInsCompPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}