using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFLinkages;

namespace NewLMS.Umkm.MediatR.Features.RFLinkages.Commands
{
    public class RFLinkagePostValidator : AbstractValidator<RFLinkagePostCommand>
    {
        public RFLinkagePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}