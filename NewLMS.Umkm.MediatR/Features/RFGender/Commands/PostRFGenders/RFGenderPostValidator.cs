using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFGenders;

namespace NewLMS.Umkm.MediatR.Features.RFGenders.Commands
{
    public class RFGenderPostValidator : AbstractValidator<RFGenderPostCommand>
    {
        public RFGenderPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}