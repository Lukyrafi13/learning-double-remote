using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Commands
{
    public class RfSectorLBU1DeleteValidator : AbstractValidator<RfSectorLBU1DeleteRequest>
    {
        public RfSectorLBU1DeleteValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
