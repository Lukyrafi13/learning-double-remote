using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisAsuransis;

namespace NewLMS.UMKM.MediatR.Features.RFJenisAsuransis.Commands
{
    public class RFJenisAsuransiPostValidator : AbstractValidator<RFJenisAsuransiPostCommand>
    {
        public RFJenisAsuransiPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}