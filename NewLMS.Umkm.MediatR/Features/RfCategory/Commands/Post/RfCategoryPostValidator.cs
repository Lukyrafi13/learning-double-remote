using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCategories;

namespace NewLMS.UMKM.MediatR.Features.RfCategories.Commands
{
    public class RfCategoryPostValidator : AbstractValidator<RfCategoryPostCommand>
    {
        public RfCategoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}