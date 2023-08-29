using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Commands
{
    public class RfSectorLBU1PostValidator : AbstractValidator<RfSectorLBU1PostRequest>
    {
        public RfSectorLBU1PostValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
