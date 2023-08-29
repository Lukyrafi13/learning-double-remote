using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFOwnerOTSs;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerOTSs.Commands
{
    public class RFOwnerOTSPostValidator : AbstractValidator<RFOwnerOTSPostCommand>
    {
        public RFOwnerOTSPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}