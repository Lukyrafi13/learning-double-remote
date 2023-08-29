using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU3s.Commands
{
    public class RfSectorLBU3PutValidator : AbstractValidator<RfSectorLBU3PutRequest>
    {
        public RfSectorLBU3PutValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode2).NotEmpty().WithMessage("LBCode2 is required");
        }
    }
}
