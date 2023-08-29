using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfTargetStatuses;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuses.Commands
{
    public class RfTargetStatusPostValidator : AbstractValidator<RfTargetStatusPostCommand>
    {
        public RfTargetStatusPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}