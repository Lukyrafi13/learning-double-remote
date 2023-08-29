using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;

namespace NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Commands
{
    public class RFMappingAgunan2PostValidator : AbstractValidator<RFMappingAgunan2PostCommand>
    {
        public RFMappingAgunan2PostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}