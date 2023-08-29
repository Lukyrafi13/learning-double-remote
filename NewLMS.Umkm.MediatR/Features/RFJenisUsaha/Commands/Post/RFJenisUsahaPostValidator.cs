using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Commands
{
    public class RFJenisUsahaPostValidator : AbstractValidator<RFJenisUsahaPostCommand>
    {
        public RFJenisUsahaPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}