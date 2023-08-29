using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFApprTanahLnkPertumbuhans;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLnkPertumbuhans.Commands
{
    public class RFApprTanahLnkPertumbuhanPostValidator : AbstractValidator<RFApprTanahLnkPertumbuhanPostCommand>
    {
        public RFApprTanahLnkPertumbuhanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}