using FluentValidation;
using NewLMS.UMKM.Data.Dto.SCJabatans;

namespace NewLMS.UMKM.MediatR.Features.SCJabatans.Commands
{
    public class SCJabatansPostValidator : AbstractValidator<SCJabatanPostCommand>
    {
        public SCJabatansPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}