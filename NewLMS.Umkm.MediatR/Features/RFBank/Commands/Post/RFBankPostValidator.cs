using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFBanks;

namespace NewLMS.Umkm.MediatR.Features.RFBanks.Commands
{
    public class RFBankPostValidator : AbstractValidator<RFBankPostCommand>
    {
        public RFBankPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}