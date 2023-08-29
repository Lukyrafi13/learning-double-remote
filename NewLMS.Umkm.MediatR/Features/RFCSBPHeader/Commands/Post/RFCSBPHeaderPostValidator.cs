using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFCSBPHeaders;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPHeaders.Commands
{
    public class RFCSBPHeaderPostValidator : AbstractValidator<RFCSBPHeaderPostCommand>
    {
        public RFCSBPHeaderPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}