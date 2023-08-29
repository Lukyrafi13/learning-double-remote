using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJOBs;

namespace NewLMS.UMKM.MediatR.Features.RFJOBs.Commands
{
    public class RFJOBPostValidator : AbstractValidator<RFJOBSPostCommand>
    {
        public RFJOBPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}