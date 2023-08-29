using FluentValidation;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;

namespace NewLMS.Umkm.MediatR.Features.SurveySuppliers.Commands
{
    public class SurveySupplierPostValidator : AbstractValidator<SurveySupplierPostCommand>
    {
        public SurveySupplierPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}