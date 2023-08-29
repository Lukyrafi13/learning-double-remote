using FluentValidation;
using NewLMS.UMKM.Data.Dto.SIKPHistoryDetails;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistoryDetails.Commands
{
    public class SIKPHistoryDetailPostValidator : AbstractValidator<SIKPHistoryDetailPostCommand>
    {
        public SIKPHistoryDetailPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}