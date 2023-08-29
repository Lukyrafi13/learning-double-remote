using FluentValidation;
using NewLMS.Umkm.Data.Dto.EnumSandiBIGroups;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBIGroups.Commands
{
    public class EnumSandiBIGroupPostValidator : AbstractValidator<EnumSandiBIGroupPostCommand>
    {
        public EnumSandiBIGroupPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}