using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFCSBPDetails;

namespace NewLMS.Umkm.MediatR.Features.RFCSBPDetails.Commands
{
    public class RFCSBPDetailPostValidator : AbstractValidator<RFCSBPDetailPostCommand>
    {
        public RFCSBPDetailPostValidator()
        {
            // RuleFor(c => c.).NotEmpty().WithMessage("NoIdentity is required");
        }
    }
}