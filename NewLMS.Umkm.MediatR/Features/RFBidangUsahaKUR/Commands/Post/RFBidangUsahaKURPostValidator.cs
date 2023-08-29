using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFBidangUsahaKURs;

namespace NewLMS.Umkm.MediatR.Features.RFBidangUsahaKURs.Commands
{
    public class RFBidangUsahaKURPostValidator : AbstractValidator<RFBidangUsahaKURPostCommand>
    {
        public RFBidangUsahaKURPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}