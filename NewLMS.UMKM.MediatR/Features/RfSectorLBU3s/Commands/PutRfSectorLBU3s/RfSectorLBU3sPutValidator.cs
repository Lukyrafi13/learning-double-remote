using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands
{
    public class RFSectorLBU3PutValidator : AbstractValidator<RFSectorLBU3PutRequest>
    {
        public RFSectorLBU3PutValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode2).NotEmpty().WithMessage("LBCode2 is required");
        }
    }
}
