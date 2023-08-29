using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFTenors;

namespace NewLMS.UMKM.MediatR.Features.RFTenors.Commands
{
    public class RFTenorPostValidator : AbstractValidator<RFTenorPostCommand>
    {
        public RFTenorPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}