using FluentValidation;
using NewLMS.UMKM.Data.Dto.SlikHistoryKredits;

namespace NewLMS.UMKM.MediatR.Features.SlikHistoryKredits.Commands
{
    public class SlikHistoryKreditPostValidator : AbstractValidator<SlikHistoryKreditPostCommand>
    {
        public SlikHistoryKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}