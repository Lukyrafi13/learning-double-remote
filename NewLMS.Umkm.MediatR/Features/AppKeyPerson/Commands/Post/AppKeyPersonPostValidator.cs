using FluentValidation;
using NewLMS.Umkm.Data.Dto.AppKeyPersons;

namespace NewLMS.Umkm.MediatR.Features.AppKeyPersons.Commands
{
    public class AppKeyPersonPostValidator : AbstractValidator<AppKeyPersonPostCommand>
    {
        public AppKeyPersonPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}