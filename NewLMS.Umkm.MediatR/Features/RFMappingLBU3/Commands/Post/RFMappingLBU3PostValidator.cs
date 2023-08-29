using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFMappingLBU3s;

namespace NewLMS.UMKM.MediatR.Features.RFMappingLBU3s.Commands
{
    public class RFMappingLBU3PostValidator : AbstractValidator<RFMappingLBU3PostCommand>
    {
        public RFMappingLBU3PostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}