using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCOTINGKATKEBUTUHANs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Commands
{
    public class RFSCOTINGKATKEBUTUHANPostValidator : AbstractValidator<RFSCOTINGKATKEBUTUHANPostCommand>
    {
        public RFSCOTINGKATKEBUTUHANPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}