using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Commands
{
    public class RfSectorLBU2PostValidator : AbstractValidator<RfSectorLBU2PostRequest>
    {
        public RfSectorLBU2PostValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode1).NotEmpty().WithMessage("LBUCode1 is required");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
