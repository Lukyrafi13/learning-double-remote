using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFNegaraPenempatans;

namespace NewLMS.Umkm.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanPostValidator : AbstractValidator<RFNegaraPenempatanPostCommand>
    {
        public RFNegaraPenempatanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}