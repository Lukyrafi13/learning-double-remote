using FluentValidation;
using NewLMS.UMKM.Data.Dto.MSearchs;

namespace NewLMS.UMKM.MediatR.Features.MSearchs.Commands
{
    public class MSearchPostValidator : AbstractValidator<MSearchPostCommand>
    {
        public MSearchPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}