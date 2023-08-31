using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Commands
{
    public class RfCreditTypePostValidator : AbstractValidator<RfCreditTypePostCommand>
    {
        public RfCreditTypePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}