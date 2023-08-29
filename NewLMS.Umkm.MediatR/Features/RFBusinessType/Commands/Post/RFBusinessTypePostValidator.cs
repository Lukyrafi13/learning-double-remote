using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFBusinessTypes;

namespace NewLMS.Umkm.MediatR.Features.RFBusinessTypes.Commands
{
    public class RFBusinessTypePostValidator : AbstractValidator<RFBusinessTypePostCommand>
    {
        public RFBusinessTypePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}