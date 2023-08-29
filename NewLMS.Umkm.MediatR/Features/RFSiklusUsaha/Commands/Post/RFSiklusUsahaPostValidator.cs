using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Commands
{
    public class RFSiklusUsahaPostValidator : AbstractValidator<RFSiklusUsahaPostCommand>
    {
        public RFSiklusUsahaPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}