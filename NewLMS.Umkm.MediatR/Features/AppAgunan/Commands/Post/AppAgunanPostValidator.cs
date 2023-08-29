using FluentValidation;
using NewLMS.Umkm.Data.Dto.AppAgunans;

namespace NewLMS.Umkm.MediatR.Features.AppAgunans.Commands
{
    public class AppAgunanPostValidator : AbstractValidator<AppAgunanPostCommand>
    {
        public AppAgunanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}