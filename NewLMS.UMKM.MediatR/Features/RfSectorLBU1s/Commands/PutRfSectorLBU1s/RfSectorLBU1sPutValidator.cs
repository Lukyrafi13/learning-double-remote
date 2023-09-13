using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands
{
    public class RFSectorLBU1PutValidator : AbstractValidator<RFSectorLBU1PutRequest>
    {
        public RFSectorLBU1PutValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Code is required");
        }
    }
}
