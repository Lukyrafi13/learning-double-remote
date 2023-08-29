using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFLokasiTempatUsahas;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiTempatUsahas.Commands
{
    public class RFLokasiTempatUsahaPostValidator : AbstractValidator<RFLokasiTempatUsahaPostCommand>
    {
        public RFLokasiTempatUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}