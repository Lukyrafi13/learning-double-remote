using FluentValidation;
using NewLMS.Umkm.Data.Dto.SIKPHistorys;

namespace NewLMS.Umkm.MediatR.Features.SIKPHistorys.Commands
{
    public class SIKPHistoryPostValidator : AbstractValidator<SIKPHistoryPostCommand>
    {
        public SIKPHistoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}