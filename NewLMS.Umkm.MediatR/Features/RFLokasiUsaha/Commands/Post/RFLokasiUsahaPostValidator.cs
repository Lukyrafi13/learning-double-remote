using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFLokasiUsahas;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiUsahas.Commands
{
    public class RFLokasiUsahaPostValidator : AbstractValidator<RFLokasiUsahaPostCommand>
    {
        public RFLokasiUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}