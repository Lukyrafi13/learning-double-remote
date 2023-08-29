using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOCARATRANSAKSIs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOCARATRANSAKSIS.Commands
{
    public class RFSCOCARATRANSAKSIPostValidator : AbstractValidator<RFSCOCARATRANSAKSISPostCommand>
    {
        public RFSCOCARATRANSAKSIPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}