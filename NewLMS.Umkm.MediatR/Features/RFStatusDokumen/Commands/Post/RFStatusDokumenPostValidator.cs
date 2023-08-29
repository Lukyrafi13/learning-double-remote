using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFStatusDokumens;

namespace NewLMS.Umkm.MediatR.Features.RFStatusDokumens.Commands
{
    public class RFStatusDokumenPostValidator : AbstractValidator<RFStatusDokumenPostCommand>
    {
        public RFStatusDokumenPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}