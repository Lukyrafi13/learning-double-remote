using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfBranchess;

namespace NewLMS.UMKM.MediatR.Features.RfBranchess.Commands
{
    public class RFBranchesPostValidator : AbstractValidator<RfBranchesPostCommand>
    {
        public RFBranchesPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}