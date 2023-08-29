using Bjb.DigitalBisnis.CoreBanking.Models.AddRetailLoan;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.RLP
{
    public class RLPValidator : AbstractValidator<BaseCoreBankingRequest<RLPRequest>>
    {
        public RLPValidator() 
        { 
        }
    }
}
