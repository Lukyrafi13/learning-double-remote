using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFInsRateMappings;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateMappings.Commands
{
    public class RFInsRateMappingPostValidator : AbstractValidator<RFInsRateMappingPostCommand>
    {
        public RFInsRateMappingPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}