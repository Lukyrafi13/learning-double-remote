using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSubProductTenors;

namespace NewLMS.Umkm.MediatR.Features.RFSubProductTenors.Commands
{
    public class RFSubProductTenorPostValidator : AbstractValidator<RFSubProductTenorPostCommand>
    {
        public RFSubProductTenorPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}