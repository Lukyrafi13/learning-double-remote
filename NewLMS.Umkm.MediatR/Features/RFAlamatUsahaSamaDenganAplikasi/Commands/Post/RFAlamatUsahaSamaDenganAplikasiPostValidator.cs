using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;

namespace NewLMS.UMKM.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Commands
{
    public class RFAlamatUsahaSamaDenganAplikasiPostValidator : AbstractValidator<RFAlamatUsahaSamaDenganAplikasiPostCommand>
    {
        public RFAlamatUsahaSamaDenganAplikasiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}