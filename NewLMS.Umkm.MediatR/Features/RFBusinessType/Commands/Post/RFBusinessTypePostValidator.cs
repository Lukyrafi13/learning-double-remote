using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFBusinessTypes;

namespace NewLMS.UMKM.MediatR.Features.RFBusinessTypes.Commands
{
    public class RFBusinessTypePostValidator : AbstractValidator<RFBusinessTypePostCommand>
    {
        public RFBusinessTypePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}