using FluentValidation;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AddRetailLoan
{
    public class AddRetailLoanValidator : AbstractValidator<BaseCoreBankingRequest<AddRetailLoanRequest>>
    {
        public AddRetailLoanValidator()
        {
            RuleFor(x => x.MPI.ZLNR21).MaximumLength(35);
            RuleFor(x => x.MPI.ZLLNP).MaximumLength(3);
            RuleFor(x => x.MPI.ZLBRNM).MaximumLength(4);
            RuleFor(x => x.MPI.ZLCPNC).MaximumLength(6);
            RuleFor(x => x.MPI.ZLCCY).MaximumLength(3);
            RuleFor(x => x.MPI.ZLDLAZ).MaximumLength(20);
            RuleFor(x => x.MPI.ZLOPAZ).MaximumLength(20);
            RuleFor(x => x.MPI.ZLCLT).MaximumLength(1);
            RuleFor(x => x.MPI.ZLRTMZ).MaximumLength(13);
            RuleFor(x => x.MPI.ZLIDB).MaximumLength(1);
            RuleFor(x => x.MPI.ZLCPIZ).MaximumLength(1);
            RuleFor(x => x.MPI.ZLPRPZ).MaximumLength(1);
            RuleFor(x => x.MPI.ZLRPYM).MaximumLength(1);
            RuleFor(x => x.MPI.ZLDDC).MaximumLength(1);
            RuleFor(x => x.MPI.ZLSCHC).MaximumLength(1);
            RuleFor(x => x.MPI.ZLNPYA).MaximumLength(3);
            RuleFor(x => x.MPI.ZLRPAZ).MaximumLength(20);
            RuleFor(x => x.MPI.ZLDIF).MaximumLength(1);
            RuleFor(x => x.MPI.ZLAB).MaximumLength(4);
            RuleFor(x => x.MPI.ZLEAN).MaximumLength(20);
            RuleFor(x => x.MPI.ZLAN).MaximumLength(6);
            RuleFor(x => x.MPI.ZLAS).MaximumLength(3);
            RuleFor(x => x.MPI.ZLCCYR).MaximumLength(3);
            RuleFor(x => x.MPI.ZLABP).MaximumLength(4);
            RuleFor(x => x.MPI.ZLEAN1).MaximumLength(20);
            RuleFor(x => x.MPI.ZLANP).MaximumLength(6);
            RuleFor(x => x.MPI.ZLASP).MaximumLength(3);
            RuleFor(x => x.MPI.ZLCCYP).MaximumLength(3);
            RuleFor(x => x.MPI.ZLABI).MaximumLength(4);
            RuleFor(x => x.MPI.ZLEAN2).MaximumLength(20);
            RuleFor(x => x.MPI.ZLANI).MaximumLength(6);
            RuleFor(x => x.MPI.ZLASI).MaximumLength(3);
            RuleFor(x => x.MPI.ZLCCYP).MaximumLength(3);
            RuleFor(x => x.MPI.ZLCCYI).MaximumLength(3);
            RuleFor(x => x.MPI.ZLSAPZ).MaximumLength(1);
            RuleFor(x => x.MPI.ZLCC1).MaximumLength(2);
            RuleFor(x => x.MPI.ZLCC2).MaximumLength(2);
            RuleFor(x => x.MPI.ZLNR22).MaximumLength(35);
            RuleFor(x => x.MPI.ZLNDAZ).MaximumLength(1);
            RuleFor(x => x.MPI.ZLPEGZ).MaximumLength(1);
            RuleFor(x => x.MPI.ZLRPQ).MaximumLength(3);
            RuleFor(x => x.MPI.ZLACO).MaximumLength(3);
            RuleFor(x => x.MPI.ZLCUS).MaximumLength(6);
            RuleFor(x => x.MPI.ZLIFQ).MaximumLength(3);
        }
    }
}
