using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFInsRateMappings;

namespace NewLMS.UMKM.MediatR.Features.RFInsRateMappings.Commands
{
    public class RFInsRateMappingPostValidator : AbstractValidator<RFInsRateMappingPostCommand>
    {
        public RFInsRateMappingPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}