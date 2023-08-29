using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFTenorMappings;

namespace NewLMS.Umkm.MediatR.Features.RFTenorMappings.Commands
{
    public class RFTenorMappingPostValidator : AbstractValidator<RFTenorMappingPostCommand>
    {
        public RFTenorMappingPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}