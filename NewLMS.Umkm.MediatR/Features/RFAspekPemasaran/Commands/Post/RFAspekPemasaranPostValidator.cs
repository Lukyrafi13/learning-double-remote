using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFAspekPemasarans;

namespace NewLMS.Umkm.MediatR.Features.RFAspekPemasarans.Commands
{
    public class RFAspekPemasaranPostValidator : AbstractValidator<RFAspekPemasaranPostCommand>
    {
        public RFAspekPemasaranPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}