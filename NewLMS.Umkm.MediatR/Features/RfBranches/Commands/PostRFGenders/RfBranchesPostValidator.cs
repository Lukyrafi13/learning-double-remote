using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfBranchess;

namespace NewLMS.Umkm.MediatR.Features.RfBranchess.Commands
{
    public class RFBranchesPostValidator : AbstractValidator<RfBranchesPostCommand>
    {
        public RFBranchesPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}