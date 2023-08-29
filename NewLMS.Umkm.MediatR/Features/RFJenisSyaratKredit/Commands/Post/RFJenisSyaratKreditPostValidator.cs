using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits;

namespace NewLMS.Umkm.MediatR.Features.RFJenisSyaratKredits.Commands
{
    public class RFJenisSyaratKreditPostValidator : AbstractValidator<RFJenisSyaratKreditPostCommand>
    {
        public RFJenisSyaratKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}