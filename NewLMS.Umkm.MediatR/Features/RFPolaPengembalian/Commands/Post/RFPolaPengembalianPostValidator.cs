using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFPolaPengembalians;

namespace NewLMS.Umkm.MediatR.Features.RFPolaPengembalians.Commands
{
    public class RFPolaPengembalianPostValidator : AbstractValidator<RFPolaPengembalianPostCommand>
    {
        public RFPolaPengembalianPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}