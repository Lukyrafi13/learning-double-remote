using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFLinkages;

namespace NewLMS.UMKM.MediatR.Features.RFLinkages.Commands
{
    public class RFLinkagePostValidator : AbstractValidator<RFLinkagePostCommand>
    {
        public RFLinkagePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}