using FluentValidation;
using NewLMS.UMKM.Data.Dto.Prospects;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands
{
    public class ProspectPostValidator : AbstractValidator<ProspectPostCommand>
    {
        public ProspectPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}