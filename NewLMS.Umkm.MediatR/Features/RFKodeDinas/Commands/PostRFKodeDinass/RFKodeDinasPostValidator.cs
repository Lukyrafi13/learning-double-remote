using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFKodeDinass;

namespace NewLMS.UMKM.MediatR.Features.RFKodeDinass.Commands
{
    public class RFKodeDinasPostValidator : AbstractValidator<RFKodeDinasPostCommand>
    {
        public RFKodeDinasPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}