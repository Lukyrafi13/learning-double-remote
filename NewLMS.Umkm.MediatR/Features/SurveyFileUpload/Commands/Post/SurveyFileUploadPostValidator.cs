using FluentValidation;
using NewLMS.Umkm.Data.Dto.SurveyFileUploads;

namespace NewLMS.Umkm.MediatR.Features.SurveyFileUploads.Commands
{
    public class SurveyFileUploadPostValidator : AbstractValidator<SurveyFileUploadPostCommand>
    {
        public SurveyFileUploadPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}