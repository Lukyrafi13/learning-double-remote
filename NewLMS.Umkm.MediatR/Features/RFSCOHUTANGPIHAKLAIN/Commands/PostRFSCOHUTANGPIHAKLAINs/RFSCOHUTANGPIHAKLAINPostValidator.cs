using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOHUTANGPIHAKLAINs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Commands
{
    public class RFSCOHUTANGPIHAKLAINPostValidator : AbstractValidator<RFSCOHUTANGPIHAKLAINPostCommand>
    {
        public RFSCOHUTANGPIHAKLAINPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}