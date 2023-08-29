using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFVEHMAKERs;

namespace NewLMS.Umkm.MediatR.Features.RFVEHMAKERs.Commands
{
    public class RFVEHMAKERPostValidator : AbstractValidator<RFVEHMAKERPostCommand>
    {
        public RFVEHMAKERPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}