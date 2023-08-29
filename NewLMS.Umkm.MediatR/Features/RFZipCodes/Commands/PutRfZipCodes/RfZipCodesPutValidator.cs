using FluentValidation;
using NewLMS.Umkm.Data.Dto.RFZipCodes;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands
{
    public class RFZipCodePutValidator : AbstractValidator<RFZipCodePutRequest>
    {
        public RFZipCodePutValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
