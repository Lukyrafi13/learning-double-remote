using FluentValidation;
using NewLMS.Umkm.Data.Dto.FileUrls;

namespace NewLMS.Umkm.MediatR.Features.FileUrls.Commands
{
    public class FileUrlPostValidator : AbstractValidator<FileUrlPostCommand>
    {
        public FileUrlPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}