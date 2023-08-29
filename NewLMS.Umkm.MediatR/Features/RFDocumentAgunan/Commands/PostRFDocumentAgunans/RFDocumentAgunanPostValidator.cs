using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFDocumentAgunans;

namespace NewLMS.Umkm.MediatR.Features.RFDocumentAgunans.Commands
{
    public class RFDocumentAgunanPostValidator : AbstractValidator<RFDocumentAgunanPostCommand>
    {
        public RFDocumentAgunanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}