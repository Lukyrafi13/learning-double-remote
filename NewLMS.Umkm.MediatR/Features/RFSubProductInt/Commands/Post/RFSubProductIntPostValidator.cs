using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSubProductInts;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductInts.Commands
{
    public class RFSubProductIntPostValidator : AbstractValidator<RFSubProductIntPostCommand>
    {
        public RFSubProductIntPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}