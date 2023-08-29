using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas;

namespace NewLMS.UMKM.MediatR.Features.RFJenisTempatUsahas.Commands
{
    public class RFJenisTempatUsahaPostValidator : AbstractValidator<RFJenisTempatUsahaPostCommand>
    {
        public RFJenisTempatUsahaPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}