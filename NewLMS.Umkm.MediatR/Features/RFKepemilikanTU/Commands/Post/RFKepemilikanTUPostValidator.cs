using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFKepemilikanTUs;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanTUs.Commands
{
    public class RFKepemilikanTUPostValidator : AbstractValidator<RFKepemilikanTUPostCommand>
    {
        public RFKepemilikanTUPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}