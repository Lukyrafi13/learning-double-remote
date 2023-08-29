using FluentValidation;
using NewLMS.Umkm.Data.Dto.SlikRequestObjects;

namespace NewLMS.Umkm.MediatR.Features.SlikRequestObjects.Commands
{
    public class SlikRequestObjectPostValidator : AbstractValidator<SlikRequestObjectPostCommand>
    {
        public SlikRequestObjectPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}