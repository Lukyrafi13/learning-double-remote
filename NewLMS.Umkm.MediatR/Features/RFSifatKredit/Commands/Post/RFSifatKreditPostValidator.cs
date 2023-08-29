using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSifatKredits;

namespace NewLMS.Umkm.MediatR.Features.RFSifatKredits.Commands
{
    public class RFSifatKreditPostValidator : AbstractValidator<RFSifatKreditPostCommand>
    {
        public RFSifatKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}