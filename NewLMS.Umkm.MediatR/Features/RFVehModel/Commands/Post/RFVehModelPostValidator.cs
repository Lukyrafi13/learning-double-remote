using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFVehModels;

namespace NewLMS.Umkm.MediatR.Features.RFVehModels.Commands
{
    public class RFVehModelPostValidator : AbstractValidator<RFVehModelPostCommand>
    {
        public RFVehModelPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}