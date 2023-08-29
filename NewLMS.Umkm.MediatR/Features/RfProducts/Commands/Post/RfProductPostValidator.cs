using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfProducts;

namespace NewLMS.UMKM.MediatR.Features.RfProducts.Commands
{
    public class RfProductPostValidator : AbstractValidator<RfProductPostCommand>
    {
        public RfProductPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}