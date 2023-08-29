using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFDebiturMemilikiUsahaLains;

namespace NewLMS.Umkm.MediatR.Features.RFDebiturMemilikiUsahaLains.Commands
{
    public class RFDebiturMemilikiUsahaLainPostValidator : AbstractValidator<RFDebiturMemilikiUsahaLainPostCommand>
    {
        public RFDebiturMemilikiUsahaLainPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}