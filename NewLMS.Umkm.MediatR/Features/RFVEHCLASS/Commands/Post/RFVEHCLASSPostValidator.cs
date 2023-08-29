using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFVEHCLASSs;

namespace NewLMS.UMKM.MediatR.Features.RFVEHCLASSs.Commands
{
    public class RFVEHCLASSPostValidator : AbstractValidator<RFVEHCLASSPostCommand>
    {
        public RFVEHCLASSPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}