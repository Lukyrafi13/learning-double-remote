using FluentValidation;
using NewLMS.Umkm.Data.Dto.BiayaInvestasis;

namespace NewLMS.Umkm.MediatR.Features.BiayaInvestasis.Commands
{
    public class BiayaInvestasiPostValidator : AbstractValidator<BiayaInvestasiPostCommand>
    {
        public BiayaInvestasiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}