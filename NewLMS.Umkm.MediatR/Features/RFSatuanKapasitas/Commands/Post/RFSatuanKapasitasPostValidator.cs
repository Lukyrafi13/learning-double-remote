using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Commands
{
    public class RFSatuanKapasitasPostValidator : AbstractValidator<RFSatuanKapasitasPostCommand>
    {
        public RFSatuanKapasitasPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}