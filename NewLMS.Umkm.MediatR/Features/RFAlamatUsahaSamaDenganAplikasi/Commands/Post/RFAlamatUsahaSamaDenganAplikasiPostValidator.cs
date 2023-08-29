using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;

namespace NewLMS.Umkm.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Commands
{
    public class RFAlamatUsahaSamaDenganAplikasiPostValidator : AbstractValidator<RFAlamatUsahaSamaDenganAplikasiPostCommand>
    {
        public RFAlamatUsahaSamaDenganAplikasiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}