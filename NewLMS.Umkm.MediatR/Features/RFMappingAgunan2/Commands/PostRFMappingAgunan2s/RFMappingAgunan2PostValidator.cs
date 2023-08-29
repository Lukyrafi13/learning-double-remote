using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFMappingAgunan2s;

namespace NewLMS.UMKM.MediatR.Features.RFMappingAgunan2s.Commands
{
    public class RFMappingAgunan2PostValidator : AbstractValidator<RFMappingAgunan2PostCommand>
    {
        public RFMappingAgunan2PostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}