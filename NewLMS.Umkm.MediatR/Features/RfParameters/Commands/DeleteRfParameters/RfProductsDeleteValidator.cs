using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfParameters;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Commands.DeleteRfParameters
{
    public class RfParameterDeleteValidator : AbstractValidator<RfParameterDeleteRequest>
    {
        public RfParameterDeleteValidator()
        {
            RuleFor(c => c.ParameterId).NotEmpty().WithMessage("Id is required");
        }
    }
}
