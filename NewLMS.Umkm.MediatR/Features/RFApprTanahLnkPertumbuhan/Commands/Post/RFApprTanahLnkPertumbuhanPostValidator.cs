using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFApprTanahLnkPertumbuhans;

namespace NewLMS.Umkm.MediatR.Features.RFApprTanahLnkPertumbuhans.Commands
{
    public class RFApprTanahLnkPertumbuhanPostValidator : AbstractValidator<RFApprTanahLnkPertumbuhanPostCommand>
    {
        public RFApprTanahLnkPertumbuhanPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}