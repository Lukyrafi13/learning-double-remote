using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSkemaSIKPs;

namespace NewLMS.UMKM.MediatR.Features.RFSkemaSIKPs.Commands
{
    public class RFSkemaSIKPPostValidator : AbstractValidator<RFSkemaSIKPPostCommand>
    {
        public RFSkemaSIKPPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}