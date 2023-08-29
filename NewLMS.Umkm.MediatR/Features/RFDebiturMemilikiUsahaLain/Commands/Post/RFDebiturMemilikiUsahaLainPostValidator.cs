using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;

namespace NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Commands
{
    public class RFDebiturMemilikiUsahaLainPostValidator : AbstractValidator<RFDebiturMemilikiUsahaLainPostCommand>
    {
        public RFDebiturMemilikiUsahaLainPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}