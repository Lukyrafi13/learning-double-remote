using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFOwnerOTSs;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerOTSs.Commands
{
    public class RFOwnerOTSPostValidator : AbstractValidator<RFOwnerOTSPostCommand>
    {
        public RFOwnerOTSPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}