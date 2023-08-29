﻿using Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountList
{
    public class AccountListValidator : AbstractValidator<BaseCoreBankingRequest<AccountListRequest>>
    {
    }
}
