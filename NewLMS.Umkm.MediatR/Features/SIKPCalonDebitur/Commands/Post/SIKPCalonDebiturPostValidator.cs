using FluentValidation;
using NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs;

namespace NewLMS.Umkm.MediatR.Features.SIKPCalonDebiturs.Commands
{
    public class SIKPCalonDebiturPostValidator : AbstractValidator<SIKPCalonDebiturPostCommand>
    {
        public SIKPCalonDebiturPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}