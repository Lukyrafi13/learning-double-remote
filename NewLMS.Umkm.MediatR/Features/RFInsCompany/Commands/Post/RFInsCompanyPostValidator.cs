using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFInsCompanys;

namespace NewLMS.Umkm.MediatR.Features.RFInsCompanys.Commands
{
    public class RFInsCompanyPostValidator : AbstractValidator<RFInsCompanyPostCommand>
    {
        public RFInsCompanyPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}