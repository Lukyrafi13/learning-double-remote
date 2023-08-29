using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFDocuments;

namespace NewLMS.Umkm.MediatR.Features.RFDocuments.Commands
{
    public class RFDocumentPostValidator : AbstractValidator<RFDocumentPostCommand>
    {
        public RFDocumentPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}