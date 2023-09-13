using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands
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
