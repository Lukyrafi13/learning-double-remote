using FluentValidation;
using NewLMS.Umkm.MediatR.Features.AppraisalImages.Commands;
using NewLMS.Umkm.MediatR.Features.DocumentSurveys.Commands;

namespace NewLMS.Umkm.MediatR.Features.DocumentSurveyors.Commands
{
    public class DocumentSurveyorsUploadValidator : AbstractValidator<DocumentSurveyorsUploadCommand>
    {
        public DocumentSurveyorsUploadValidator() 
        {
            RuleFor(x => x.AppraisalGuid).NotNull();
            RuleFor(x => x.DocumentType).NotNull();
            RuleFor(x => x.Files).SetValidator(new FileValidatorDocumentSurvey());
        }
    }
}
