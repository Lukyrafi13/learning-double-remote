using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFStatusDokumens;

namespace NewLMS.UMKM.MediatR.Features.RFStatusDokumens.Commands
{
    public class RFStatusDokumenPostValidator : AbstractValidator<RFStatusDokumenPostCommand>
    {
        public RFStatusDokumenPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}