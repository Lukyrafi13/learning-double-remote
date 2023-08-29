using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFRejects;

namespace NewLMS.Umkm.MediatR.Features.RFRejects.Commands
{
    public class RFRejectPostValidator : AbstractValidator<RFRejectPostCommand>
    {
        public RFRejectPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}