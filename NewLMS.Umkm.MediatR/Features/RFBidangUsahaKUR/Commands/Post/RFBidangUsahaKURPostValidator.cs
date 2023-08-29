using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs;

namespace NewLMS.UMKM.MediatR.Features.RFBidangUsahaKURs.Commands
{
    public class RFBidangUsahaKURPostValidator : AbstractValidator<RFBidangUsahaKURPostCommand>
    {
        public RFBidangUsahaKURPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}