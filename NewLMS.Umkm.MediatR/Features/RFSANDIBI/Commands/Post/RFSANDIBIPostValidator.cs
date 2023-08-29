using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSANDIBIS;

namespace NewLMS.Umkm.MediatR.Features.RFSANDIBIS.Commands
{
    public class RFSANDIBIPostValidator : AbstractValidator<RFSANDIBIPostCommand>
    {
        public RFSANDIBIPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}