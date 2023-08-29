using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Commands
{
    public class RFKelompokUsahaPostValidator : AbstractValidator<RFKelompokUsahaPostCommand>
    {
        public RFKelompokUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}