using FluentValidation;
using NewLMS.UMKM.Data.Dto.SurveySuppliers;

namespace NewLMS.UMKM.MediatR.Features.SurveySuppliers.Commands
{
    public class SurveySupplierPostValidator : AbstractValidator<SurveySupplierPostCommand>
    {
        public SurveySupplierPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}