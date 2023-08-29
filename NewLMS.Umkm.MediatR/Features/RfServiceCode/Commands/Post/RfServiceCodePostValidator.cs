using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;

namespace NewLMS.UMKM.MediatR.Features.RfServiceCodes.Commands
{
    public class RfServiceCodePostValidator : AbstractValidator<RfServiceCodePostCommand>
    {
        public RfServiceCodePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}