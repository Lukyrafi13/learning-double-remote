using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFRejects;

namespace NewLMS.UMKM.MediatR.Features.RFRejects.Commands
{
    public class RFRejectPostValidator : AbstractValidator<RFRejectPostCommand>
    {
        public RFRejectPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}