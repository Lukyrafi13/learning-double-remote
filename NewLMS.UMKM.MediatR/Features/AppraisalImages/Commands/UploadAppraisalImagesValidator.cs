using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace NewLMS.UMKM.MediatR.Features.AppraisalImages.Commands
{
    public class FileValidatorAppraisalImage : AbstractValidator<IFormFile>
    {
        public FileValidatorAppraisalImage()
        {
            RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(10485760) //10MB
                .WithMessage("File size is larger than allowed (10 MB).");

            var AllowedMimeTypes = Helper.FileStorage.DEFAULT_IMAGE_MIMETYPES;

            RuleFor(x => x.ContentType).NotNull().Must(x => AllowedMimeTypes.Contains(x))
                .WithMessage("File type is not allowed. Only image files are permitted.");
        }
    }

    public class UploadAppraisalImagesValidator : AbstractValidator<UploadAppraisalImagesCommand>
    {
        public UploadAppraisalImagesValidator()
        {
            RuleFor(x => x.AppraisalGuid).NotNull();
            RuleFor(x => x.DocumentType).NotNull();
            RuleFor(x => x.Files).SetValidator(new FileValidatorAppraisalImage());
        }
    }
}
