using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Commands
{
    public class RfCompanyTypePostValidator : AbstractValidator<RfCompanyTypePostCommand>
    {
        public RfCompanyTypePostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}