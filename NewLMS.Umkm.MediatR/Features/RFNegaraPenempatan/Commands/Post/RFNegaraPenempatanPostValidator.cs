using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;

namespace NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanPostValidator : AbstractValidator<RFNegaraPenempatanPostCommand>
    {
        public RFNegaraPenempatanPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}