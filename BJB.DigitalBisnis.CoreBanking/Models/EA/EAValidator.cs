using Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.EA
{
    public class EAValidator : AbstractValidator<BaseCoreBankingRequest<EARequest>>
    {
        public EAValidator()
        {
            RuleFor(x => x.MPI.ZLEANC).NotEmpty();
            RuleFor(x => x.MPI.PGNUM).NotEmpty();
            RuleFor(x => x.MPI.PGSIZE).NotEmpty();
        }
    }
}