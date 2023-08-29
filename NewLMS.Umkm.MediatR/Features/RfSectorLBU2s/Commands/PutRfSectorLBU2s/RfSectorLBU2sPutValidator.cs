using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Commands
{
    public class RfSectorLBU2PutValidator : AbstractValidator<RfSectorLBU2PutRequest>
    {
        public RfSectorLBU2PutValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode1).NotEmpty().WithMessage("LBCode1 is required");
        }
    }
}
