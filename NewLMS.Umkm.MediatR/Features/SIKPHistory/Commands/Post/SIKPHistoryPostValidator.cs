using FluentValidation;
using NewLMS.UMKM.Data.Dto.SIKPHistorys;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistorys.Commands
{
    public class SIKPHistoryPostValidator : AbstractValidator<SIKPHistoryPostCommand>
    {
        public SIKPHistoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}