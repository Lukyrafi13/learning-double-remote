using FluentValidation;
using NewLMS.UMKM.Data.Dto.EnumSandiBIGroups;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBIGroups.Commands
{
    public class EnumSandiBIGroupPostValidator : AbstractValidator<EnumSandiBIGroupPostCommand>
    {
        public EnumSandiBIGroupPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}