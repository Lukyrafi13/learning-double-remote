using FluentValidation;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;

namespace NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Commands
{
    public class SlikCreditHistoryPostValidator : AbstractValidator<SlikCreditHistoryPostCommand>
    {
        public SlikCreditHistoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}