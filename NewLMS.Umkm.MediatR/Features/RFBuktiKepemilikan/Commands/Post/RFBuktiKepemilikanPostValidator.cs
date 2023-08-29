using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFBuktiKepemilikans;

namespace NewLMS.UMKM.MediatR.Features.RFBuktiKepemilikans.Commands
{
    public class RFBuktiKepemilikanPostValidator : AbstractValidator<RFBuktiKepemilikanPostCommand>
    {
        public RFBuktiKepemilikanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}