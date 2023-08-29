using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Commands
{
    public class RfSectorLBU2DeleteValidator : AbstractValidator<RfSectorLBU2DeleteRequest>
    {
        public RfSectorLBU2DeleteValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
