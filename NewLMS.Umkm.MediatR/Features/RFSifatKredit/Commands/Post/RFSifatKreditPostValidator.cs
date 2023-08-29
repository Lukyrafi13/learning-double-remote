using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;

namespace NewLMS.UMKM.MediatR.Features.RFSifatKredits.Commands
{
    public class RFSifatKreditPostValidator : AbstractValidator<RFSifatKreditPostCommand>
    {
        public RFSifatKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}