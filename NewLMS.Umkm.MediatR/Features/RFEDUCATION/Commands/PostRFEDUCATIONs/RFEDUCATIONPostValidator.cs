using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFEDUCATIONs;

namespace NewLMS.UMKM.MediatR.Features.RFEDUCATIONs.Commands
{
    public class RFEDUCATIONPostValidator : AbstractValidator<RFEDUCATIONPostCommand>
    {
        public RFEDUCATIONPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}