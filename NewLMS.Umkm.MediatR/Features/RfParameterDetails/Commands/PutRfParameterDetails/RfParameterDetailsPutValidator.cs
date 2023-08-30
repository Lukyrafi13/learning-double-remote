using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.PutRfParameterDetails
{
    public class RfParameterDetailPutValidator : AbstractValidator<RfParameterDetailPutRequest>
    {
        public RfParameterDetailPutValidator()
        {
            RuleFor(c => c.ParameterDetailId).NotEmpty().WithMessage("ParameterDetailId is required");
        }
    }
}
