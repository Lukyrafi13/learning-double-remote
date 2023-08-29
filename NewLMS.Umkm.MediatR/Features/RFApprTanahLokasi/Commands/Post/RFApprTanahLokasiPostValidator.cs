using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFApprTanahLokasis;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLokasis.Commands
{
    public class RFApprTanahLokasiPostValidator : AbstractValidator<RFApprTanahLokasiPostCommand>
    {
        public RFApprTanahLokasiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}