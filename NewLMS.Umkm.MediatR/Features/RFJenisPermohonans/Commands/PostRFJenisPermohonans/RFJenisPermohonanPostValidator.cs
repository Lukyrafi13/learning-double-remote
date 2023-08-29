using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;

namespace NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Commands
{
    public class RFJenisPermohonanPostValidator : AbstractValidator<RFJenisPermohonanPostCommand>
    {
        public RFJenisPermohonanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}