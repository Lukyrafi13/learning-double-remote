using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFKodeDinass;

namespace NewLMS.Umkm.MediatR.Features.RFKodeDinass.Commands
{
    public class RFKodeDinasPostValidator : AbstractValidator<RFKodeDinasPostCommand>
    {
        public RFKodeDinasPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}