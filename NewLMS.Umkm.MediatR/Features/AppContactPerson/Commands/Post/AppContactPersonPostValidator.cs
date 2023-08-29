using FluentValidation;
using NewLMS.Umkm.Data.Dto.AppContactPersons;

namespace NewLMS.Umkm.MediatR.Features.AppContactPersons.Commands
{
    public class AppContactPersonPostValidator : AbstractValidator<AppContactPersonPostCommand>
    {
        public AppContactPersonPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}