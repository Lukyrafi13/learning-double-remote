using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFZipCodes;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands
{
    public class RFZipCodeDeleteValidator : AbstractValidator<RFZipCodeDeleteRequest>
    {
        public RFZipCodeDeleteValidator()
        {
            RuleFor(c => c.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        }
    }
}
