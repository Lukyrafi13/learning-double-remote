using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfCategorys;

namespace NewLMS.UMKM.MediatR.Features.RfCategorys.Commands
{
    public class RfCategoryPostValidator : AbstractValidator<RfCategoryPostCommand>
    {
        public RfCategoryPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}