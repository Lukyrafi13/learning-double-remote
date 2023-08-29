using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSatuanKapasitass;

namespace NewLMS.UMKM.MediatR.Features.RFSatuanKapasitass.Commands
{
    public class RFSatuanKapasitasPostValidator : AbstractValidator<RFSatuanKapasitasPostCommand>
    {
        public RFSatuanKapasitasPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}