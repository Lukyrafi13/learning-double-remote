using FluentValidation;
using NewLMS.UMKM.Data.Dto.FileUrls;

namespace NewLMS.UMKM.MediatR.Features.FileUrls.Commands
{
    public class FileUrlPostValidator : AbstractValidator<FileUrlPostCommand>
    {
        public FileUrlPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}