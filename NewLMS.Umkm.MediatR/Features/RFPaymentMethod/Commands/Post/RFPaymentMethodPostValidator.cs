using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFPaymentMethods;

namespace NewLMS.UMKM.MediatR.Features.RFPaymentMethods.Commands
{
    public class RFPaymentMethodPostValidator : AbstractValidator<RFPaymentMethodPostCommand>
    {
        public RFPaymentMethodPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}