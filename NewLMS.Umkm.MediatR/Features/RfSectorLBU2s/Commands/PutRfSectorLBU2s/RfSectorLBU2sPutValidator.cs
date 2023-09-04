using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands
{
    public class RFSectorLBU2PutValidator : AbstractValidator<RFSectorLBU2PutRequest>
    {
        public RFSectorLBU2PutValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode1).NotEmpty().WithMessage("LBCode1 is required");
        }
    }
}
