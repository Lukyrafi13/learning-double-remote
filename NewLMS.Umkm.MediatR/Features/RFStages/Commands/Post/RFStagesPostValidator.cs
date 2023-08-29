using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFStagess;

namespace NewLMS.Umkm.MediatR.Features.RFStagess.Commands
{
    public class RFStagesPostValidator : AbstractValidator<RFStagesPostCommand>
    {
        public RFStagesPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}