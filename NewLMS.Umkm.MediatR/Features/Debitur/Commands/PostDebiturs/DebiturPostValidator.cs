using FluentValidation;
using NewLMS.Umkm.Data.Dto.Debiturs;

namespace NewLMS.Umkm.MediatR.Features.Debiturs.Commands
{
    public class DebiturPostValidator : AbstractValidator<DebiturPostCommand>
    {
        public DebiturPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}