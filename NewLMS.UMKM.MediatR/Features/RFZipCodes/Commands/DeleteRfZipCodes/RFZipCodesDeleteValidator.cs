﻿using FluentValidation;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodeDeleteValidator : AbstractValidator<RfZipCodeDeleteRequest>
    {
        public RfZipCodeDeleteValidator()
        {
            RuleFor(c => c.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        }
    }
}
