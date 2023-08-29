using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFOwnerCategories;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Commands
{
    public class RfOwnerCategoryPostValidator : AbstractValidator<RfOwnerCategoryPostCommand>
    {
        public RfOwnerCategoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}