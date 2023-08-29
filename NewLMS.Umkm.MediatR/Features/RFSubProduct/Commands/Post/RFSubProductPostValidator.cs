using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSubProducts;

namespace NewLMS.UMKM.MediatR.Features.RFSubProducts.Commands
{
    public class RFSubProductPostValidator : AbstractValidator<RFSubProductPostCommand>
    {
        public RFSubProductPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}