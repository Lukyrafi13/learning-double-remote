using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFSiklusUsahas.Commands
{
    public class RFSiklusUsahaPostValidator : AbstractValidator<RFSiklusUsahaPostCommand>
    {
        public RFSiklusUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}