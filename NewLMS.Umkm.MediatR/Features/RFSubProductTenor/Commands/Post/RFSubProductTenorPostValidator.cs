using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Commands
{
    public class RFSubProductTenorPostValidator : AbstractValidator<RFSubProductTenorPostCommand>
    {
        public RFSubProductTenorPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}