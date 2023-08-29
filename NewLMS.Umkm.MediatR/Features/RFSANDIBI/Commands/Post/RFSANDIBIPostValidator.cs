using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSANDIBIS;

namespace NewLMS.UMKM.MediatR.Features.RFSANDIBIS.Commands
{
    public class RFSANDIBIPostValidator : AbstractValidator<RFSANDIBIPostCommand>
    {
        public RFSANDIBIPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}