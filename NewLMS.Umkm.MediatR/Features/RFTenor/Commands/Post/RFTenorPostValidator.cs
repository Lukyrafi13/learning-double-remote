using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFTenors;

namespace NewLMS.Umkm.MediatR.Features.RFTenors.Commands
{
    public class RFTenorPostValidator : AbstractValidator<RFTenorPostCommand>
    {
        public RFTenorPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}