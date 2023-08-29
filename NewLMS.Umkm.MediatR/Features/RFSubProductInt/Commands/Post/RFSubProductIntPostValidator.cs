using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSubProductInts;

namespace NewLMS.Umkm.MediatR.Features.RFSubProductInts.Commands
{
    public class RFSubProductIntPostValidator : AbstractValidator<RFSubProductIntPostCommand>
    {
        public RFSubProductIntPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}