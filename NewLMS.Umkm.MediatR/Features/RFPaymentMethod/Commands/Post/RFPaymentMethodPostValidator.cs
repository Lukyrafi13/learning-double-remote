using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFPaymentMethods;

namespace NewLMS.Umkm.MediatR.Features.RFPaymentMethods.Commands
{
    public class RFPaymentMethodPostValidator : AbstractValidator<RFPaymentMethodPostCommand>
    {
        public RFPaymentMethodPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}