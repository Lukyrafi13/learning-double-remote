using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFJenisKendaraanAgunans;

namespace NewLMS.Umkm.MediatR.Features.RFJenisKendaraanAgunans.Commands
{
    public class RFJenisKendaraanAgunanPostValidator : AbstractValidator<RFJenisKendaraanAgunanPostCommand>
    {
        public RFJenisKendaraanAgunanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}