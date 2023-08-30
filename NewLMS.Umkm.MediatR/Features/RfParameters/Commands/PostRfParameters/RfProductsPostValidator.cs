using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfParameters;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Commands.PostRfParameters
{
    public class RfParameterPostValidator : AbstractValidator<RfParameterPostRequest>
    {
        public RfParameterPostValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
