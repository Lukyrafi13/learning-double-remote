using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSubProducts;

namespace NewLMS.Umkm.MediatR.Features.RFSubProducts.Commands
{
    public class RFSubProductPostValidator : AbstractValidator<RFSubProductPostCommand>
    {
        public RFSubProductPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}