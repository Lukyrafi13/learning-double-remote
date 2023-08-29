using FluentValidation;
using NewLMS.UMKM.Data.Dto.RFCSBPDetails;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPDetails.Commands
{
    public class RFCSBPDetailPostValidator : AbstractValidator<RFCSBPDetailPostCommand>
    {
        public RFCSBPDetailPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}