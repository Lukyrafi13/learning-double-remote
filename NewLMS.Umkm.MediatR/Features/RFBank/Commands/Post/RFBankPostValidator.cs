using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFBanks;

namespace NewLMS.UMKM.MediatR.Features.RFBanks.Commands
{
    public class RFBankPostValidator : AbstractValidator<RFBankPostCommand>
    {
        public RFBankPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}