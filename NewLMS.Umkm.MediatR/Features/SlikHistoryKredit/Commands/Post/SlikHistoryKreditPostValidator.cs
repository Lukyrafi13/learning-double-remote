using FluentValidation;
using NewLMS.Umkm.Data.Dto.SlikHistoryKredits;

namespace NewLMS.Umkm.MediatR.Features.SlikHistoryKredits.Commands
{
    public class SlikHistoryKreditPostValidator : AbstractValidator<SlikHistoryKreditPostCommand>
    {
        public SlikHistoryKreditPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}