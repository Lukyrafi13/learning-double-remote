using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFOwnerCategories;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Commands
{
    public class RFOwnerCategoryPostValidator : AbstractValidator<RFOwnerCategoryPostCommand>
    {
        public RFOwnerCategoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}