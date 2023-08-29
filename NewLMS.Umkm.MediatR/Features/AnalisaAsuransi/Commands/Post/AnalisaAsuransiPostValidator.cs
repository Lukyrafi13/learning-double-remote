using FluentValidation;
using NewLMS.Umkm.Data.Dto.AnalisaAsuransis;

namespace NewLMS.Umkm.MediatR.Features.AnalisaAsuransis.Commands
{
    public class AnalisaAsuransiPostValidator : AbstractValidator<AnalisaAsuransiPostCommand>
    {
        public AnalisaAsuransiPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}