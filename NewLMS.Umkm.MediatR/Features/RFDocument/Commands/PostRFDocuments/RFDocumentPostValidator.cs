using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFDocuments;

namespace NewLMS.UMKM.MediatR.Features.RFDocuments.Commands
{
    public class RFDocumentPostValidator : AbstractValidator<RFDocumentPostCommand>
    {
        public RFDocumentPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}