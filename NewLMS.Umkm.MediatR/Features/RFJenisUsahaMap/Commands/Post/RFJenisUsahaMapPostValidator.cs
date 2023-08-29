using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Commands
{
    public class RFJenisUsahaMapPostValidator : AbstractValidator<RFJenisUsahaMapPostCommand>
    {
        public RFJenisUsahaMapPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}