using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfTargetStatuss;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuss.Commands
{
    public class RfTargetStatusPostValidator : AbstractValidator<RfTargetStatusPostCommand>
    {
        public RfTargetStatusPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}