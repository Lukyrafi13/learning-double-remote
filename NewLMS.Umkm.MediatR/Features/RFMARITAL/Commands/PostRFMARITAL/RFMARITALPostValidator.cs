using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFMARITALs;

namespace NewLMS.UMKM.MediatR.Features.RFMARITALs.Commands
{
    public class RFMARITALPostValidator : AbstractValidator<RFMARITALSPostCommand>
    {
        public RFMARITALPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}