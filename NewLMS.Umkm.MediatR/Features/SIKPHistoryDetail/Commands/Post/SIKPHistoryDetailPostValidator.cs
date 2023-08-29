using FluentValidation;
using NewLMS.Umkm.Data.Dto.SIKPHistoryDetails;

namespace NewLMS.Umkm.MediatR.Features.SIKPHistoryDetails.Commands
{
    public class SIKPHistoryDetailPostValidator : AbstractValidator<SIKPHistoryDetailPostCommand>
    {
        public SIKPHistoryDetailPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}