using FluentValidation;
using NewLMS.Umkm.Data.Dto.PersiapanAkadAsuransis;

namespace NewLMS.Umkm.MediatR.Features.PersiapanAkadAsuransis.Commands
{
    public class PersiapanAkadAsuransiPostValidator : AbstractValidator<PersiapanAkadAsuransiPostCommand>
    {
        public PersiapanAkadAsuransiPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}