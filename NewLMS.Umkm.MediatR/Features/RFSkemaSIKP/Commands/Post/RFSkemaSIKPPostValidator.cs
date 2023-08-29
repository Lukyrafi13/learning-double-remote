using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSkemaSIKPs;

namespace NewLMS.Umkm.MediatR.Features.RFSkemaSIKPs.Commands
{
    public class RFSkemaSIKPPostValidator : AbstractValidator<RFSkemaSIKPPostCommand>
    {
        public RFSkemaSIKPPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}