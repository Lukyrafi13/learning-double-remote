using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFInsCompanys;

namespace NewLMS.UMKM.MediatR.Features.RFInsCompanys.Commands
{
    public class RFInsCompanyPostValidator : AbstractValidator<RFInsCompanyPostCommand>
    {
        public RFInsCompanyPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}