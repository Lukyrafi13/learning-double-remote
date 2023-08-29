using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahaPokoks.Commands
{
    public class RFSiklusUsahaPokokPostValidator : AbstractValidator<RFSiklusUsahaPokokPostCommand>
    {
        public RFSiklusUsahaPokokPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}