using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJOBs;

namespace NewLMS.Umkm.MediatR.Features.RFJOBs.Commands
{
    public class RFJOBPostValidator : AbstractValidator<RFJOBSPostCommand>
    {
        public RFJOBPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}