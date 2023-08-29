using FluentValidation;
using NewLMS.Umkm.Data.Dto.SPPKFileUploads;

namespace NewLMS.Umkm.MediatR.Features.SPPKFileUploads.Commands
{
    public class SPPKFileUploadPostValidator : AbstractValidator<SPPKFileUploadPostCommand>
    {
        public SPPKFileUploadPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}