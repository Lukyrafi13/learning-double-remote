using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFMappingPrescreeningDocuments;

namespace NewLMS.UMKM.MediatR.Features.RFMappingPrescreeningDocuments.Commands
{
    public class RFMappingPrescreeningDocumentPostValidator : AbstractValidator<RFMappingPrescreeningDocumentPostCommand>
    {
        public RFMappingPrescreeningDocumentPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}