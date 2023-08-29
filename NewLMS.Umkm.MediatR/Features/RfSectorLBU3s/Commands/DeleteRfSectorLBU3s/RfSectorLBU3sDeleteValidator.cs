using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU3s.Commands
{
    public class RfSectorLBU3DeleteValidator : AbstractValidator<RfSectorLBU3DeleteRequest>
    {
        public RfSectorLBU3DeleteValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
