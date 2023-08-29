using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands
{
    public class RFSectorLBU2DeleteValidator : AbstractValidator<RFSectorLBU2DeleteRequest>
    {
        public RFSectorLBU2DeleteValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
