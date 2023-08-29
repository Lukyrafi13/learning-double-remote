using FluentValidation;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Commands
{
    public class EnumSandiBITypePostValidator : AbstractValidator<EnumSandiBITypePostCommand>
    {
        public EnumSandiBITypePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}