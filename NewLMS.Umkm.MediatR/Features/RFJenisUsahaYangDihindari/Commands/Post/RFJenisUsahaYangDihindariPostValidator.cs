using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Commands
{
    public class RfCompanyTypeYangDihindariPostValidator : AbstractValidator<RfCompanyTypeYangDihindariPostCommand>
    {
        public RfCompanyTypeYangDihindariPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}