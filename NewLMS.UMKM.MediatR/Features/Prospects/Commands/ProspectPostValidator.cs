using FluentValidation;
using NewLMS.Umkm.Data.Dto.Prospects;

namespace NewLMS.Umkm.MediatR.Features.Prospects.Commands
{
    public class ProspectPostValidator : AbstractValidator<ProspectPostCommand>
    {
        public ProspectPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}