using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSatuanLuass;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanLuass.Commands
{
    public class RFSatuanLuasPostValidator : AbstractValidator<RFSatuanLuasPostCommand>
    {
        public RFSatuanLuasPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}