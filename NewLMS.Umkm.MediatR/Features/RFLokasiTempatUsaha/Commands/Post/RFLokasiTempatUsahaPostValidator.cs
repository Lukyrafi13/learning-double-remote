using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFLokasiTempatUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiTempatUsahas.Commands
{
    public class RFLokasiTempatUsahaPostValidator : AbstractValidator<RFLokasiTempatUsahaPostCommand>
    {
        public RFLokasiTempatUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}