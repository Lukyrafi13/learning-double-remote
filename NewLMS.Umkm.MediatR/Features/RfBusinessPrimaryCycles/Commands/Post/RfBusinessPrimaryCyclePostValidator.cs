using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycle;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCycle.Commands
{
    public class RfBusinessPrimaryCyclePostValidator : AbstractValidator<RfBusinessPrimaryCiclePostCommand>
    {
        public RfBusinessPrimaryCyclePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}