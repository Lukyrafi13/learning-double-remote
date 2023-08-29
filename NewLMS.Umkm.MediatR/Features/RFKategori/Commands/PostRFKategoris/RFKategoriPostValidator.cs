using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFKategoris;

namespace NewLMS.Umkm.MediatR.Features.RFKategoris.Commands
{
    public class RFKategoriPostValidator : AbstractValidator<RFKategoriPostCommand>
    {
        public RFKategoriPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}