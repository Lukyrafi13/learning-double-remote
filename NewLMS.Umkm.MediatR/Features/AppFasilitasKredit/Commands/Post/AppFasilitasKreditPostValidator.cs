using FluentValidation;
using NewLMS.Umkm.Data.Dto.AppFasilitasKredits;

namespace NewLMS.Umkm.MediatR.Features.AppFasilitasKredits.Commands
{
    public class AppFasilitasKreditPostValidator : AbstractValidator<AppFasilitasKreditPostCommand>
    {
        public AppFasilitasKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}