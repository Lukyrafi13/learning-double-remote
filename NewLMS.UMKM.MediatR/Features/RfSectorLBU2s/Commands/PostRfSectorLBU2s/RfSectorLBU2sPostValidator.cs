using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands
{
    public class RFSectorLBU2PostValidator : AbstractValidator<RFSectorLBU2PostRequest>
    {
        public RFSectorLBU2PostValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode1).NotEmpty().WithMessage("LBUCode1 is required");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
