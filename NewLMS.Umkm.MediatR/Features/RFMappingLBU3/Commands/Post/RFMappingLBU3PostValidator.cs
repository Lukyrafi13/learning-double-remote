using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFMappingLBU3s;

namespace NewLMS.Umkm.MediatR.Features.RFMappingLBU3s.Commands
{
    public class RFMappingLBU3PostValidator : AbstractValidator<RFMappingLBU3PostCommand>
    {
        public RFMappingLBU3PostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}