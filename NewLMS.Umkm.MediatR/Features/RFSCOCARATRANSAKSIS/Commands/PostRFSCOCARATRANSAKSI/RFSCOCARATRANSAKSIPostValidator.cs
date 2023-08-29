using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOCARATRANSAKSIs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOCARATRANSAKSIS.Commands
{
    public class RFSCOCARATRANSAKSIPostValidator : AbstractValidator<RFSCOCARATRANSAKSISPostCommand>
    {
        public RFSCOCARATRANSAKSIPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}