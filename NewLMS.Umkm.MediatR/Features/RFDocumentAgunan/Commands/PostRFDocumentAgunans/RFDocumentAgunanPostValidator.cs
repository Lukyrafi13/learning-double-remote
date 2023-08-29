using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFDocumentAgunans;

namespace NewLMS.UMKM.MediatR.Features.RFDocumentAgunans.Commands
{
    public class RFDocumentAgunanPostValidator : AbstractValidator<RFDocumentAgunanPostCommand>
    {
        public RFDocumentAgunanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}