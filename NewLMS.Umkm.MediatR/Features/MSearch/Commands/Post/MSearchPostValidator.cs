using FluentValidation;
using NewLMS.Umkm.Data.Dto.MSearchs;

namespace NewLMS.Umkm.MediatR.Features.MSearchs.Commands
{
    public class MSearchPostValidator : AbstractValidator<MSearchPostCommand>
    {
        public MSearchPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}