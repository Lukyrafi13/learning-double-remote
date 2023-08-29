using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFJenisKendaraanAgunans;

namespace NewLMS.UMKM.MediatR.Features.RFJenisKendaraanAgunans.Commands
{
    public class RFJenisKendaraanAgunanPostValidator : AbstractValidator<RFJenisKendaraanAgunanPostCommand>
    {
        public RFJenisKendaraanAgunanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}