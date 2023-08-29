using FluentValidation;
using NewLMS.Umkm.Data.Dto.SCJabatans;

namespace NewLMS.Umkm.MediatR.Features.SCJabatans.Commands
{
    public class SCJabatansPostValidator : AbstractValidator<SCJabatanPostCommand>
    {
        public SCJabatansPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}