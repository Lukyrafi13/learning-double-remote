using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands
{
    public class RFSectorLBU3DeleteValidator : AbstractValidator<RFSectorLBU3DeleteRequest>
    {
        public RFSectorLBU3DeleteValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
