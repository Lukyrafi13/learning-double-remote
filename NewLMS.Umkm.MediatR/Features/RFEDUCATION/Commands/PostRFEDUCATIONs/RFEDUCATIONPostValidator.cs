using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFEDUCATIONs;

namespace NewLMS.Umkm.MediatR.Features.RFEDUCATIONs.Commands
{
    public class RFEDUCATIONPostValidator : AbstractValidator<RFEDUCATIONPostCommand>
    {
        public RFEDUCATIONPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}