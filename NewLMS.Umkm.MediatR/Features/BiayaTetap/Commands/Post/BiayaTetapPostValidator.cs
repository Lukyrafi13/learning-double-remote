using FluentValidation;
using NewLMS.Umkm.Data.Dto.BiayaTetaps;

namespace NewLMS.Umkm.MediatR.Features.BiayaTetaps.Commands
{
    public class BiayaTetapPostValidator : AbstractValidator<BiayaTetapPostCommand>
    {
        public BiayaTetapPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}