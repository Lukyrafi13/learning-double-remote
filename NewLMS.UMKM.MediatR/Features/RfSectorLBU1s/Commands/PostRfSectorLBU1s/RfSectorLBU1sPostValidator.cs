using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands
{
    public class RFSectorLBU1PostValidator : AbstractValidator<RFSectorLBU1PostRequest>
    {
        public RFSectorLBU1PostValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
