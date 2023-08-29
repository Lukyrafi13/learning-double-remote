using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFKepemilikanUsahas;

namespace NewLMS.UMKM.MediatR.Features.RFKepemilikanUsahas.Commands
{
    public class RFKepemilikanUsahaPostValidator : AbstractValidator<RFKepemilikanUsahaPostCommand>
    {
        public RFKepemilikanUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}