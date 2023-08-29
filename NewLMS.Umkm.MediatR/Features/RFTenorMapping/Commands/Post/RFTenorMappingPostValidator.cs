using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFTenorMappings;

namespace NewLMS.UMKM.MediatR.Features.RFTenorMappings.Commands
{
    public class RFTenorMappingPostValidator : AbstractValidator<RFTenorMappingPostCommand>
    {
        public RFTenorMappingPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}