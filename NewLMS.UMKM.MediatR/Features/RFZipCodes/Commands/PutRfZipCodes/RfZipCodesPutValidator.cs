using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfZipCodes;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodePutValidator : AbstractValidator<RfZipCodePutRequest>
    {
        public RfZipCodePutValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
