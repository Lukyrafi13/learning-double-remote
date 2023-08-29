using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;

namespace NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Commands
{
    public class RFJenisDuplikasiPostValidator : AbstractValidator<RFJenisDuplikasiPostCommand>
    {
        public RFJenisDuplikasiPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}