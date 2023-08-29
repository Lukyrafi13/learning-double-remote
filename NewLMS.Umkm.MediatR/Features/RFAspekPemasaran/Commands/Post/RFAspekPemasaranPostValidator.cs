using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFAspekPemasarans;

namespace NewLMS.UMKM.MediatR.Features.RFAspekPemasarans.Commands
{
    public class RFAspekPemasaranPostValidator : AbstractValidator<RFAspekPemasaranPostCommand>
    {
        public RFAspekPemasaranPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}