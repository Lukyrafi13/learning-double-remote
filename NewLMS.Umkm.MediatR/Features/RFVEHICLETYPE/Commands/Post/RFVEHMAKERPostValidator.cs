using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFVEHICLETYPEs;

namespace NewLMS.UMKM.MediatR.Features.RFVEHICLETYPEss.Commands
{
    public class RFVEHICLETYPEPostValidator : AbstractValidator<RFVEHICLETYPEPostCommand>
    {
        public RFVEHICLETYPEPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}