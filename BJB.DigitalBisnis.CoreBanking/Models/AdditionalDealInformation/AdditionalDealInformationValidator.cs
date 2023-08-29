using Bjb.DigitalBisnis.CoreBanking.Models.AdditionalAccountInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AdditionalDealInformation
{
    public class AdditionalDealInformationValidator : AbstractValidator<BaseCoreBankingRequest<AdditionalDealInformationRequest>>
    {
        public AdditionalDealInformationValidator()
        {
            RuleFor(x => x.MPI.BUEQF).MaximumLength(2);
            RuleFor(x => x.MPI.BULPV).MaximumLength(10);
            RuleFor(x => x.MPI.BUIGR).MaximumLength(5);
            RuleFor(x => x.MPI.BUBRNM).MaximumLength(4);
            RuleFor(x => x.MPI.BUDLP).MaximumLength(3);
            RuleFor(x => x.MPI.BUDLR).MaximumLength(13);
            RuleFor(x => x.MPI.BUPSQ).MaximumLength(5);
            RuleFor(x => x.MPI.BUPOD).MaximumLength(7);
            RuleFor(x => x.MPI.BUD001).MaximumLength(4);
            RuleFor(x => x.MPI.BUD002).MaximumLength(4);
            RuleFor(x => x.MPI.BUD003).MaximumLength(3);
            RuleFor(x => x.MPI.BUD005).MaximumLength(2);
            RuleFor(x => x.MPI.BUD006).MaximumLength(1);
            RuleFor(x => x.MPI.BUD008).MaximumLength(1);
            RuleFor(x => x.MPI.BUD009).MaximumLength(6);
            RuleFor(x => x.MPI.BUD011).MaximumLength(1);
            RuleFor(x => x.MPI.BUD012).MaximumLength(15);
            RuleFor(x => x.MPI.BUD013).MaximumLength(15);
            RuleFor(x => x.MPI.BUD014).MaximumLength(15);
            RuleFor(x => x.MPI.BUD015).MaximumLength(1);
            RuleFor(x => x.MPI.BUD004).MaximumLength(4);
            RuleFor(x => x.MPI.BUD016).MaximumLength(5);
            RuleFor(x => x.MPI.BUD018).MaximumLength(7);
            RuleFor(x => x.MPI.BUD019).MaximumLength(2);
            RuleFor(x => x.MPI.BUD021).MaximumLength(8);
            RuleFor(x => x.MPI.BUD023).MaximumLength(35);
            RuleFor(x => x.MPI.BUSL02).MaximumLength(5);
            RuleFor(x => x.MPI.BUSL05).MaximumLength(13);
            RuleFor(x => x.MPI.BUSL06).MaximumLength(9);
            RuleFor(x => x.MPI.BUMARD).MaximumLength(13);
            RuleFor(x => x.MPI.BUMARG).MaximumLength(13);
            RuleFor(x => x.MPI.BUD024).MaximumLength(4);
            RuleFor(x => x.MPI.BUD025).MaximumLength(15);
            RuleFor(x => x.MPI.BUD026).MaximumLength(13);
            RuleFor(x => x.MPI.BUD046).MaximumLength(25);
            RuleFor(x => x.MPI.BUD027).MaximumLength(7);
            RuleFor(x => x.MPI.BUD035).MaximumLength(4);
            RuleFor(x => x.MPI.BUD047).MaximumLength(7);
            RuleFor(x => x.MPI.BUD048).MaximumLength(7);
            RuleFor(x => x.MPI.BUD049).MaximumLength(2);
            RuleFor(x => x.MPI.BUD052).MaximumLength(15);
            RuleFor(x => x.MPI.BUD053).MaximumLength(15);
            RuleFor(x => x.MPI.BUD054).MaximumLength(1);
            RuleFor(x => x.MPI.BUD081).MaximumLength(1);
            RuleFor(x => x.MPI.BUD084).MaximumLength(1);
            RuleFor(x => x.MPI.BUD088).MaximumLength(15);
            RuleFor(x => x.MPI.BUD106).MaximumLength(1);
            RuleFor(x => x.MPI.BUD107).MaximumLength(1);
            RuleFor(x => x.MPI.BUD112).MaximumLength(15);
        }
    }
}
