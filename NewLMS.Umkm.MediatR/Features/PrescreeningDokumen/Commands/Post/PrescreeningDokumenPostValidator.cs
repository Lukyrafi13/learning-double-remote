using FluentValidation;
using NewLMS.Umkm.Data.Dto.PrescreeningDokumens;

namespace NewLMS.Umkm.MediatR.Features.PrescreeningDokumens.Commands
{
    public class PrescreeningDokumenPostValidator : AbstractValidator<PrescreeningDokumenPostCommand>
    {
        public PrescreeningDokumenPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}