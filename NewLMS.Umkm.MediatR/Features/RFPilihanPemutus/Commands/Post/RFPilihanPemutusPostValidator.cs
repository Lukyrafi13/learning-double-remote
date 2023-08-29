using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFPilihanPemutuss;

namespace NewLMS.Umkm.MediatR.Features.RFPilihanPemutuss.Commands
{
    public class RFPilihanPemutusPostValidator : AbstractValidator<RFPilihanPemutusPostCommand>
    {
        public RFPilihanPemutusPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}