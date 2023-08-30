using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.PostRfParameterDetails
{
    public class RfParameterDetailPostValidator : AbstractValidator<RfParameterDetailPostRequest>
    {
        public RfParameterDetailPostValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
