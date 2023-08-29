using FluentValidation;
using NewLMS.Umkm.Data.Dto.AnalisaSyaratKredits;

namespace NewLMS.Umkm.MediatR.Features.AnalisaSyaratKredits.Commands
{
    public class AnalisaSyaratKreditPostValidator : AbstractValidator<AnalisaSyaratKreditPostCommand>
    {
        public AnalisaSyaratKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}