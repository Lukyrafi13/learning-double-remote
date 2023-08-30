using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycles;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCycles.Commands
{
    public class RfBusinessPrimaryCyclePostValidator : AbstractValidator<RfBusinessPrimaryCiclePostCommand>
    {
        public RfBusinessPrimaryCyclePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}