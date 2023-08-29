using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisTempatUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFJenisTempatUsahas.Commands
{
    public class RFJenisTempatUsahaPostValidator : AbstractValidator<RFJenisTempatUsahaPostCommand>
    {
        public RFJenisTempatUsahaPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}