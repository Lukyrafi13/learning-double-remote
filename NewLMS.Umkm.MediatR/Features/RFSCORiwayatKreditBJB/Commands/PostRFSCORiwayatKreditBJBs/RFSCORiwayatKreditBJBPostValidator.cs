using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFSCORiwayatKreditBJBs;

namespace NewLMS.UMKM.MediatR.Features.RFSCORiwayatKreditBJBs.Commands
{
    public class RFSCORiwayatKreditBJBPostValidator : AbstractValidator<RFSCORiwayatKreditBJBPostCommand>
    {
        public RFSCORiwayatKreditBJBPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}