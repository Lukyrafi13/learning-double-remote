using FluentValidation;
using NewLMS.Umkm.Data.Dto.ApprovalHistorys;

namespace NewLMS.Umkm.MediatR.Features.ApprovalHistorys.Commands
{
    public class ApprovalHistoryPostValidator : AbstractValidator<ApprovalHistoryPostCommand>
    {
        public ApprovalHistoryPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}