using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFRelationCols;

namespace NewLMS.UMKM.MediatR.Features.RFRelationCols.Commands
{
    public class RFRelationColPostValidator : AbstractValidator<RFRelationColPostCommand>
    {
        public RFRelationColPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}