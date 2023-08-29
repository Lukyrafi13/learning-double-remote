using Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountTransactionHistory
{
    public class AccountTransactionHistoryValidator : AbstractValidator<BaseCoreBankingRequest<AccountTransactionHistoryRequest>>
    {
    }
}
