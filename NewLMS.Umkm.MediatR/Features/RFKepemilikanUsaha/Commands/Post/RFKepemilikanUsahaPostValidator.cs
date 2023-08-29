using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFKepemilikanUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanUsahas.Commands
{
    public class RFKepemilikanUsahaPostValidator : AbstractValidator<RFKepemilikanUsahaPostCommand>
    {
        public RFKepemilikanUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}