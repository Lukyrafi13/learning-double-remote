using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFApprTanahLokasis;

namespace NewLMS.Umkm.MediatR.Features.RFApprTanahLokasis.Commands
{
    public class RFApprTanahLokasiPostValidator : AbstractValidator<RFApprTanahLokasiPostCommand>
    {
        public RFApprTanahLokasiPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}