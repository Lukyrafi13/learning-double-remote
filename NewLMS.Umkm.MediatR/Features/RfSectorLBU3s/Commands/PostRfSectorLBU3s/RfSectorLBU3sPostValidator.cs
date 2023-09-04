using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands
{
    public class RFSectorLBU3PostValidator : AbstractValidator<RFSectorLBU3PostRequest>
    {
        public RFSectorLBU3PostValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.LBCode2).NotEmpty().WithMessage("LBCode2 is required");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
