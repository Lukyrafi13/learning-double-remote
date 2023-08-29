using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFKepemilikanTUs;

namespace NewLMS.UMKM.MediatR.Features.RFKepemilikanTUs.Commands
{
    public class RFKepemilikanTUPostValidator : AbstractValidator<RFKepemilikanTUPostCommand>
    {
        public RFKepemilikanTUPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}