using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFRelationCols;

namespace NewLMS.Umkm.MediatR.Features.RFRelationCols.Commands
{
    public class RFRelationColPostValidator : AbstractValidator<RFRelationColPostCommand>
    {
        public RFRelationColPostValidator(){
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}