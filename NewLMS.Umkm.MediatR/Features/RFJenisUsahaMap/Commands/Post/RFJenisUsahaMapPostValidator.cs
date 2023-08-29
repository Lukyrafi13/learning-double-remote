using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Commands
{
    public class RfCompanyTypeMapPostValidator : AbstractValidator<RfCompanyTypeMapPostCommand>
    {
        public RfCompanyTypeMapPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}