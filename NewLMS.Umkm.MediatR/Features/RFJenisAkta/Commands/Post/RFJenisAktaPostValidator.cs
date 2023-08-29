using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisAktas;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAktas.Commands
{
    public class RFJenisAktaPostValidator : AbstractValidator<RFJenisAktaPostCommand>
    {
        public RFJenisAktaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}