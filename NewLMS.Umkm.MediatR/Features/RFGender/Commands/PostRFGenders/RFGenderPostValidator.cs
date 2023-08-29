using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfGenders;

namespace NewLMS.UMKM.MediatR.Features.RfGenders.Commands
{
    public class RfGenderPostValidator : AbstractValidator<RfGenderPostCommand>
    {
        public RfGenderPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}