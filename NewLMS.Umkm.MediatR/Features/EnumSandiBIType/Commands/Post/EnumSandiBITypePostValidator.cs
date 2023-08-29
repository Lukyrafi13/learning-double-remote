using FluentValidation;
using NewLMS.UMKM.Data.Dto.EnumSandiBITypes;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBITypes.Commands
{
    public class EnumSandiBITypePostValidator : AbstractValidator<EnumSandiBITypePostCommand>
    {
        public EnumSandiBITypePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}