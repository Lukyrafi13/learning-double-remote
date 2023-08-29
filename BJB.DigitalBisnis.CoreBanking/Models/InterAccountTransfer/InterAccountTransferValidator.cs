using Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry;
using Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.InterAccountTransfer
{
    public class InterAccountTransferValidator : AbstractValidator<BaseCoreBankingRequest<InterAccountTransferRequest>>
    {
    }
}
