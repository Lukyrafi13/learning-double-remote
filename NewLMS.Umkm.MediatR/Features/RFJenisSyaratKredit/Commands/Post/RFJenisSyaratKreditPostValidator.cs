using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisSyaratKredits;

namespace NewLMS.UMKM.MediatR.Features.RFJenisSyaratKredits.Commands
{
    public class RFJenisSyaratKreditPostValidator : AbstractValidator<RFJenisSyaratKreditPostCommand>
    {
        public RFJenisSyaratKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}