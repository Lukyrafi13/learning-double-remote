using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFVEHMAKERs;

namespace NewLMS.UMKM.MediatR.Features.RFVEHMAKERs.Commands
{
    public class RFVEHMAKERPostValidator : AbstractValidator<RFVEHMAKERPostCommand>
    {
        public RFVEHMAKERPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}