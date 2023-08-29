using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFPilihanPemutuss;

namespace NewLMS.UMKM.MediatR.Features.RFPilihanPemutuss.Commands
{
    public class RFPilihanPemutusPostValidator : AbstractValidator<RFPilihanPemutusPostCommand>
    {
        public RFPilihanPemutusPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}