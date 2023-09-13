using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace NewLMS.UMKM.MediatR.Features.Documents.Commands
{
    public class FileValidators : AbstractValidator<IFormFile>
    {
        public FileValidators()
        {
            RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(2097152) //2MB
                .WithMessage("File size is larger than allowed");

            var AllowedMimeTypes = Helper.FileStorage.DEFAULT_DOCUMENT_MIMETYPES.Union(Helper.FileStorage.DEFAULT_IMAGE_MIMETYPES);

            RuleFor(x => x.ContentType).NotNull().Must(x => AllowedMimeTypes.Contains(x))
                .WithMessage("File type is not allowed");
        }
    }

    public class DocumentsUpdateValidator : AbstractValidator<DocumentsUpdateCommand>
    {
        public DocumentsUpdateValidator()
        {
            RuleFor(x => x.LoanApplicationId).NotNull();
            RuleFor(x => x.DocumentType).NotNull();
            RuleForEach(x => x.Files).SetValidator(new FileValidators());
        }
    }
}
