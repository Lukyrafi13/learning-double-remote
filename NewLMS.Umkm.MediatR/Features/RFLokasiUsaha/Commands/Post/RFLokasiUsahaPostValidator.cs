using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFLokasiUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiUsahas.Commands
{
    public class RFLokasiUsahaPostValidator : AbstractValidator<RFLokasiUsahaPostCommand>
    {
        public RFLokasiUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}