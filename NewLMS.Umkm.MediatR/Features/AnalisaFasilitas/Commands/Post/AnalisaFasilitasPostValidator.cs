using FluentValidation;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;

namespace NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Commands
{
    public class AnalisaFasilitasPostValidator : AbstractValidator<AnalisaFasilitasPostCommand>
    {
        public AnalisaFasilitasPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}