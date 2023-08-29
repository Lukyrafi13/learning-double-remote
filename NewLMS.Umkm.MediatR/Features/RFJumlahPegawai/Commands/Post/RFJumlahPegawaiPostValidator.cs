using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJumlahPegawais;

namespace NewLMS.Umkm.MediatR.Features.RFJumlahPegawais.Commands
{
    public class RFJumlahPegawaiPostValidator : AbstractValidator<RFJumlahPegawaiPostCommand>
    {
        public RFJumlahPegawaiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}