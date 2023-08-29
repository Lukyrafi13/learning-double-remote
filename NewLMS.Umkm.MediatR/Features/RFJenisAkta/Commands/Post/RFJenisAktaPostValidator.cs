using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisAktas;

namespace NewLMS.UMKM.MediatR.Features.RFJenisAktas.Commands
{
    public class RFJenisAktaPostValidator : AbstractValidator<RFJenisAktaPostCommand>
    {
        public RFJenisAktaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}