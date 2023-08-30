using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfParameters;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Commands.PutRfParameters
{
    public class RfParameterPutValidator : AbstractValidator<RfParameterPutRequest>
    {
        public RfParameterPutValidator()
        {
            RuleFor(c => c.ParameterId).NotEmpty().WithMessage("ParameterId is required");
        }
    }
}
