using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfStages;

namespace NewLMS.UMKM.MediatR.Features.RfStages.Commands
{
    public class RfStagePostValidator : AbstractValidator<RfStagePostCommand>
    {
        public RfStagePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}