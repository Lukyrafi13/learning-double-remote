using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSatuanLuass;

namespace NewLMS.UMKM.MediatR.Features.RFSatuanLuass.Commands
{
    public class RFSatuanLuasPostValidator : AbstractValidator<RFSatuanLuasPostCommand>
    {
        public RFSatuanLuasPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}