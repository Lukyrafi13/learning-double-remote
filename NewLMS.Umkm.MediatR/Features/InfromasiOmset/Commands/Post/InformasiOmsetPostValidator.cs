using FluentValidation;
using NewLMS.Umkm.Data.Dto.InformasiOmsets;

namespace NewLMS.Umkm.MediatR.Features.InformasiOmsets.Commands
{
    public class InformasiOmsetPostValidator : AbstractValidator<InformasiOmsetPostCommand>
    {
        public InformasiOmsetPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}