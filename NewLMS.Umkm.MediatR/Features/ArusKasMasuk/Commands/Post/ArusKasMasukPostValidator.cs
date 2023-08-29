using FluentValidation;
using NewLMS.Umkm.Data.Dto.ArusKasMasuks;

namespace NewLMS.Umkm.MediatR.Features.ArusKasMasuks.Commands
{
    public class ArusKasMasukPostValidator : AbstractValidator<ArusKasMasukPostCommand>
    {
        public ArusKasMasukPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}