using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands
{
    public class RFSectorLBU1DeleteValidator : AbstractValidator<RFSectorLBU1DeleteRequest>
    {
        public RFSectorLBU1DeleteValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
