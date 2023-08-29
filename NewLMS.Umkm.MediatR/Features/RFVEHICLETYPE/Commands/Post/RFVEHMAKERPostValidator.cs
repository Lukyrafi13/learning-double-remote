using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;

namespace NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Commands
{
    public class RFVEHICLETYPEPostValidator : AbstractValidator<RFVEHICLETYPEPostCommand>
    {
        public RFVEHICLETYPEPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}