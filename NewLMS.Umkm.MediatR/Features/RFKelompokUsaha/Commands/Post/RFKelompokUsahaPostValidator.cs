using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Commands
{
    public class RfCompanyGroupPostValidator : AbstractValidator<RfCompanyGroupPostCommand>
    {
        public RfCompanyGroupPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}