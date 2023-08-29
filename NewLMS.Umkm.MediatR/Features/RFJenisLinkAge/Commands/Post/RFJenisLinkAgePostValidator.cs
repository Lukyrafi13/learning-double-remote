using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisLinkAges;

namespace NewLMS.UMKM.MediatR.Features.RFJenisLinkAges.Commands
{
    public class RFJenisLinkAgePostValidator : AbstractValidator<RFJenisLinkAgePostCommand>
    {
        public RFJenisLinkAgePostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}