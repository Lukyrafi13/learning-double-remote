using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFMARITALs;

namespace NewLMS.Umkm.MediatR.Features.RFMARITALs.Commands
{
    public class RFMARITALPostValidator : AbstractValidator<RFMARITALSPostCommand>
    {
        public RFMARITALPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}