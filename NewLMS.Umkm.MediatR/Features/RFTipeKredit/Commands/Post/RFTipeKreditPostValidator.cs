using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFTipeKredits;

namespace NewLMS.Umkm.MediatR.Features.RFTipeKredits.Commands
{
    public class RFTipeKreditPostValidator : AbstractValidator<RFTipeKreditPostCommand>
    {
        public RFTipeKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}