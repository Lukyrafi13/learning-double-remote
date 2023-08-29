using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.MediatR.Features.RfZipcodes.Commands
{
    public class RfZipCodePutValidator : AbstractValidator<RfZipCodePutRequest>
    {
        public RfZipCodePutValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
