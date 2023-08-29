using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOHUTANGPIHAKLAINs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Commands
{
    public class RFSCOHUTANGPIHAKLAINPostValidator : AbstractValidator<RFSCOHUTANGPIHAKLAINPostCommand>
    {
        public RFSCOHUTANGPIHAKLAINPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}