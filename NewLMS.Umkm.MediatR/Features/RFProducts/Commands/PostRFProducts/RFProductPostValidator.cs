using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFProducts;

namespace NewLMS.Umkm.MediatR.Features.RFProducts.Commands
{
    public class RFProductPostValidator : AbstractValidator<RFProductPostCommand>
    {
        public RFProductPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}