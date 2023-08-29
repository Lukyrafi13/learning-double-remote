using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisAsuransis;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAsuransis.Commands
{
    public class RFJenisAsuransiPostValidator : AbstractValidator<RFJenisAsuransiPostCommand>
    {
        public RFJenisAsuransiPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}