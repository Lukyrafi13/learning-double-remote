using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfAppTypes;

namespace NewLMS.UMKM.MediatR.Features.RfAppTypes.Commands
{
    public class RfAppTypePostValidator : AbstractValidator<RfAppTypePostCommand>
    {
        public RfAppTypePostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}