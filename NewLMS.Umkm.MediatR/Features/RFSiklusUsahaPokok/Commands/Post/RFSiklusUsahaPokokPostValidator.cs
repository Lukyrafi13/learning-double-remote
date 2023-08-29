using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahaPokoks;

namespace NewLMS.Umkm.MediatR.Features.RFSiklusUsahaPokoks.Commands
{
    public class RFSiklusUsahaPokokPostValidator : AbstractValidator<RFSiklusUsahaPokokPostCommand>
    {
        public RFSiklusUsahaPokokPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}