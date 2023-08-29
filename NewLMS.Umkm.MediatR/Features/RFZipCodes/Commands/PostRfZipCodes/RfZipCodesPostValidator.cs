using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFZipCodes;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands
{
    public class RFZipCodePostValidator : AbstractValidator<RFZipCodePostRequest>
    {
        public RFZipCodePostValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(c => c.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        }
    }
}
