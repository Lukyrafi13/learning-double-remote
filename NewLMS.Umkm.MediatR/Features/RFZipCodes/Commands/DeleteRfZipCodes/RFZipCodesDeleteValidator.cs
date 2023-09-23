using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfZipCodes;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodeDeleteValidator : AbstractValidator<RfZipCodeDeleteRequest>
    {
        public RfZipCodeDeleteValidator()
        {
            RuleFor(c => c.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        }
    }
}
