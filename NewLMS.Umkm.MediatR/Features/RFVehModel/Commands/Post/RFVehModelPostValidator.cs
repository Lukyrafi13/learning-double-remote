using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFVehModels;

namespace NewLMS.UMKM.MediatR.Features.RFVehModels.Commands
{
    public class RFVehModelPostValidator : AbstractValidator<RFVehModelPostCommand>
    {
        public RFVehModelPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}