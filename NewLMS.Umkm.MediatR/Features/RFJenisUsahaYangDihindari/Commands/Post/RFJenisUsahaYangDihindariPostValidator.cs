using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Commands
{
    public class RFJenisUsahaYangDihindariPostValidator : AbstractValidator<RFJenisUsahaYangDihindariPostCommand>
    {
        public RFJenisUsahaYangDihindariPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}