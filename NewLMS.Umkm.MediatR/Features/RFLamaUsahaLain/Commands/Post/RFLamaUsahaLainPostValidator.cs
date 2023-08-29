using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFLamaUsahaLains;

namespace NewLMS.Umkm.MediatR.Features.RFLamaUsahaLains.Commands
{
    public class RFLamaUsahaLainPostValidator : AbstractValidator<RFLamaUsahaLainPostCommand>
    {
        public RFLamaUsahaLainPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}