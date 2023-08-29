using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisDuplikasis;

namespace NewLMS.UMKM.MediatR.Features.RFJenisDuplikasis.Commands
{
    public class RFJenisDuplikasiPostValidator : AbstractValidator<RFJenisDuplikasiPostCommand>
    {
        public RFJenisDuplikasiPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}