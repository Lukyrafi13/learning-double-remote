using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCOTINGKATKEBUTUHANs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Commands
{
    public class RFSCOTINGKATKEBUTUHANPostValidator : AbstractValidator<RFSCOTINGKATKEBUTUHANPostCommand>
    {
        public RFSCOTINGKATKEBUTUHANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}