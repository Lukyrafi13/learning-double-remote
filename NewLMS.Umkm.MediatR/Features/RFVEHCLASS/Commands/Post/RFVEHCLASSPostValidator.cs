using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFVEHCLASSs;

namespace NewLMS.Umkm.MediatR.Features.RFVEHCLASSs.Commands
{
    public class RFVEHCLASSPostValidator : AbstractValidator<RFVEHCLASSPostCommand>
    {
        public RFVEHCLASSPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}