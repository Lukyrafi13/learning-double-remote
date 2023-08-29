using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFPolaPengembalians;

namespace NewLMS.UMKM.MediatR.Features.RFPolaPengembalians.Commands
{
    public class RFPolaPengembalianPostValidator : AbstractValidator<RFPolaPengembalianPostCommand>
    {
        public RFPolaPengembalianPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}