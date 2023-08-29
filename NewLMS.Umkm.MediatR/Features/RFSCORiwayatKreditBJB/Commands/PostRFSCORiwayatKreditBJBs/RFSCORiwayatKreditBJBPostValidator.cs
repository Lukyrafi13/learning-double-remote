using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFSCORiwayatKreditBJBs;

namespace NewLMS.Umkm.MediatR.Features.RFSCORiwayatKreditBJBs.Commands
{
    public class RFSCORiwayatKreditBJBPostValidator : AbstractValidator<RFSCORiwayatKreditBJBPostCommand>
    {
        public RFSCORiwayatKreditBJBPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}