using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJumlahPegawais;

namespace NewLMS.UMKM.MediatR.Features.RFJumlahPegawais.Commands
{
    public class RFJumlahPegawaiPostValidator : AbstractValidator<RFJumlahPegawaiPostCommand>
    {
        public RFJumlahPegawaiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}