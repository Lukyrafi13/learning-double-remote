using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisLinkAges;

namespace NewLMS.Umkm.MediatR.Features.RFJenisLinkAges.Commands
{
    public class RFJenisLinkAgePostValidator : AbstractValidator<RFJenisLinkAgePostCommand>
    {
        public RFJenisLinkAgePostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}