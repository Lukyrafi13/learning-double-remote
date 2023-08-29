using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFLamaUsahaLains;

namespace NewLMS.UMKM.MediatR.Features.RFLamaUsahaLains.Commands
{
    public class RFLamaUsahaLainPostValidator : AbstractValidator<RFLamaUsahaLainPostCommand>
    {
        public RFLamaUsahaLainPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}