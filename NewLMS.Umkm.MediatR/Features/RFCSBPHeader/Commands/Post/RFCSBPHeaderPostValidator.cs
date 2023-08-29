using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFCSBPHeaders;

namespace NewLMS.Umkm.MediatR.Features.RFCSBPHeaders.Commands
{
    public class RFCSBPHeaderPostValidator : AbstractValidator<RFCSBPHeaderPostCommand>
    {
        public RFCSBPHeaderPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}