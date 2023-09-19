using FluentValidation;
using NewLMS.Umkm.Data.Dto.RfZipCodes;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodePostValidator : AbstractValidator<RfZipCodePostRequest>
    {
        public RfZipCodePostValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(c => c.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        }
    }
}
