using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFStagess;

namespace NewLMS.UMKM.MediatR.Features.RFStagess.Commands
{
    public class RFStagesPostValidator : AbstractValidator<RFStagesPostCommand>
    {
        public RFStagesPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}