using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;

namespace NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Commands
{
    public class RFBuktiKepemilikanPostValidator : AbstractValidator<RFBuktiKepemilikanPostCommand>
    {
        public RFBuktiKepemilikanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}