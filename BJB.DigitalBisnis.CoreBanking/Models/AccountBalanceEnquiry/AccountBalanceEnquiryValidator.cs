using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry
{
    public class AccountBalanceEnquiryValidator : AbstractValidator<BaseCoreBankingRequest<AccountBalanceEnquiryRequest>>
    {
        public AccountBalanceEnquiryValidator()
        {
            RuleFor(x => x.MPI.ZLean).NotNull().NotEmpty().MaximumLength(9);
        }
    }
}
