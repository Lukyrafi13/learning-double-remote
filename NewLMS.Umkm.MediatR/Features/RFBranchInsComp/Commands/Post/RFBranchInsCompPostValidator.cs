using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFBranchInsComps;

namespace NewLMS.Umkm.MediatR.Features.RFBranchInsComps.Commands
{
    public class RFBranchInsCompPostValidator : AbstractValidator<RFBranchInsCompPostCommand>
    {
        public RFBranchInsCompPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}