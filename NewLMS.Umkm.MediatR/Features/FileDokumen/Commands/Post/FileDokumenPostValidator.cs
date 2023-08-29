using FluentValidation;
using NewLMS.Umkm.Data.Dto.FileDokumens;

namespace NewLMS.Umkm.MediatR.Features.FileDokumens.Commands
{
    public class FileDokumenPostValidator : AbstractValidator<FileDokumenPostCommand>
    {
        public FileDokumenPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}