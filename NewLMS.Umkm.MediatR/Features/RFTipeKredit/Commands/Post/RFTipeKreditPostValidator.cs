using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFTipeKredits;

namespace NewLMS.UMKM.MediatR.Features.RFTipeKredits.Commands
{
    public class RFTipeKreditPostValidator : AbstractValidator<RFTipeKreditPostCommand>
    {
        public RFTipeKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}