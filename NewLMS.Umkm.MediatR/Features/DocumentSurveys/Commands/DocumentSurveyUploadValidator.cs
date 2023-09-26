using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace NewLMS.Umkm.MediatR.Features.DocumentSurveys.Commands
{
    public class FileValidatorDocumentSurvey : AbstractValidator<IFormFile>
    {
        public FileValidatorDocumentSurvey()
        {
            RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(10485760) //10MB
                .WithMessage("File size is larger than allowed (10 MB).");

            var AllowedMimeTypes = Helper.FileStorage.DEFAULT_VALID_MIMETYPES;

            RuleFor(x => x.ContentType).NotNull().Must(x => AllowedMimeTypes.Contains(x))
                .WithMessage("File type is not allowed. Only image files are permitted.");
        }
    }

    public class DocumentSurveyUploadValidator : AbstractValidator<DocumentSurveyUploadCommand>
    {
        public DocumentSurveyUploadValidator()
        {
            RuleFor(x => x.LoanApplicationId).NotNull();
            RuleFor(x => x.DocumentType).NotNull();
            RuleForEach(x => x.Files).SetValidator(new FileValidatorDocumentSurvey());
        }
    }
}
