using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.DeleteRfParameterDetails
{
    public class RfParameterDetailDeleteValidator : AbstractValidator<RfParameterDetailDeleteRequest>
    {
        public RfParameterDetailDeleteValidator()
        {
            RuleFor(c => c.ParameterDetailId).NotEmpty().WithMessage("Id is required");
        }
    }
}
