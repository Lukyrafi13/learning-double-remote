using Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold
{
    public class InputAccountHoldValidator : AbstractValidator<BaseCoreBankingRequest<InputAccountHoldRequest>>
    {
        public InputAccountHoldValidator()
        {
            RuleFor(x => x.MPI.ZLEAN).NotEmpty().MaximumLength(20);
            RuleFor(x => x.MPI.ZLSDTZ).NotEmpty().MaximumLength(6);
            // RuleFor(x => x.Mpi.ZLEDTZ).NotEmpty().MaximumLength(6);
            RuleFor(x => x.MPI.ZLAMT).NotEmpty().MaximumLength(15);
            // RuleFor(x => x.Mpi.ZLACO).NotEmpty().MaximumLength(3);
            // RuleFor(x => x.Mpi.ZLHRC).NotEmpty().MaximumLength(3);
            RuleFor(x => x.MPI.ZLHDD1).MaximumLength(35);
            RuleFor(x => x.MPI.ZLHDD2).MaximumLength(35);
            RuleFor(x => x.MPI.ZLHDD3).MaximumLength(35);
            RuleFor(x => x.MPI.ZLHDD4).MaximumLength(35);
        }
    }
}
