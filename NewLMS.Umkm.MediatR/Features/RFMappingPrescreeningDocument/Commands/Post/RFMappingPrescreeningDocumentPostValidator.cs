using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFMappingPrescreeningDocuments;

namespace NewLMS.Umkm.MediatR.Features.RFMappingPrescreeningDocuments.Commands
{
    public class RFMappingPrescreeningDocumentPostValidator : AbstractValidator<RFMappingPrescreeningDocumentPostCommand>
    {
        public RFMappingPrescreeningDocumentPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}