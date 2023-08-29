using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Commands
{
    public class RfSectorLBU1PutValidator : AbstractValidator<RfSectorLBU1PutRequest>
    {
        public RfSectorLBU1PutValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
