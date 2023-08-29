using FluentValidation;
using NewLMS.Umkm.Data.Dto.AnalisaSandiOJKs;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSandiOJKs.Commands
{
    public class AnalisaSandiOJKPostValidator : AbstractValidator<AnalisaSandiOJKPostCommand>
    {
        public AnalisaSandiOJKPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}