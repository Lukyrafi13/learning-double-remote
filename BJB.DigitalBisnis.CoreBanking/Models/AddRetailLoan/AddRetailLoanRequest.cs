using System.ComponentModel.DataAnnotations;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AddRetailLoan
{
    public class AddRetailLoanRequest
    {
        /// <summary>
        /// Narrative 2 - 1
        /// </summary>
        [MaxLength(35)]
        public string? ZLNR21 { get; set; }
        /// <summary>
        /// Loan type
        /// </summary>
        [MaxLength(3)]
        public string? ZLLNP { get; set; }
        /// <summary>
        /// Branch mnemonic
        /// </summary>
        [MaxLength(4)]
        public string? ZLBRNM { get; set; }
        /// <summary>
        /// Customer number
        /// </summary>
        [MaxLength(6)]
        public string? ZLCPNC { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        [MaxLength(3)]
        public string? ZLCCY { get; set; } = "IDR";
        /// <summary>
        /// Amount
        /// </summary>
        [MaxLength(20)]
        public string? ZLDLAZ { get; set; }
        /// <summary>
        /// Original principal / Plafond
        /// </summary>
        [MaxLength(20)]
        public string? ZLOPAZ { get; set; }
        /// <summary>
        /// Collateral Required
        /// </summary>
        [MaxLength(1)]
        public string? ZLCLT { get; set; }
        /// <summary>
        /// Base rate code / Intereset
        /// </summary>
        //[MaxLength(2)]
        //public string? ZLBRR { get; set; }
        /// <summary>
        /// Margin rate
        /// </summary>
        [MaxLength(2)]
        public string? ZLRTMZ { get; set; }
        /// <summary>
        /// Interest days basis
        /// </summary>
        [MaxLength(1)]
        public string? ZLIDB { get; set; }
        /// <summary>
        /// Capitalise interest? 
        /// </summary>
        [MaxLength(1)]
        public string? ZLCPIZ { get; set; }
        /// <summary>
        /// Repayment reminders?
        /// </summary>
        [MaxLength(1)]
        public string? ZLPRPZ { get; set; }
        /// <summary>
        /// Repayment method
        /// </summary>
        [MaxLength(1)]
        public string? ZLRPYM { get; set; }
        /// <summary>
        /// Separate DD claims?
        /// </summary>
        public string? ZLDDC { get; set; }
        /// <summary>
        /// Schedule recalculate
        /// </summary>
        [MaxLength(1)]
        public string? ZLSCHC { get; set; }
        /// <summary>
        /// Number of repayments
        /// </summary>
        [MaxLength(3)]
        public string? ZLNPYA { get; set; }
        /// <summary>
        /// Repayment amount
        /// </summary>
        [MaxLength(20)]
        public string? ZLRPAZ { get; set; }
        /// <summary>
        /// First amount can differ? 
        /// </summary>
        [MaxLength(1)]
        public string? ZLDIF { get; set; }
        /// <summary>
        /// Account branch
        /// </summary>
        [MaxLength(4)]
        public string? ZLAB { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        [MaxLength(20)]
        public string? ZLEAN { get; set; }
        /// <summary>
        /// Account basic number
        /// </summary>
        [MaxLength(6)]
        public string? ZLAN { get; set; }
        /// <summary>
        /// Account suffix
        /// </summary>
        [MaxLength(3)]
        public string? ZLAS { get; set; }
        /// <summary>
        /// Receiving account currency 
        /// </summary>
        [MaxLength(3)]
        public string? ZLCCYR { get; set; }
        /// <summary>
        /// Repay principal a/c branch 
        /// </summary>
        [MaxLength(4)]
        public string? ZLABP { get; set; }
        /// <summary>
        /// Repay principal a/c
        /// </summary>
        [MaxLength(20)]
        public string? ZLEAN1 { get; set; }
        /// <summary>
        /// Repay principal a/c basic numb
        /// </summary>
        [MaxLength(6)]
        public string? ZLANP { get; set; }
        /// <summary>
        /// Repay principal a/c suffix
        /// </summary>
        [MaxLength(3)]
        public string? ZLASP { get; set; }
        /// <summary>
        /// Repay principal a/c currency 
        /// </summary>
        [MaxLength(3)]
        public string? ZLCCYP { get; set; }
        /// <summary>
        /// Repay interest a/c branch
        /// </summary>
        [MaxLength(4)]
        public string? ZLABI { get; set; }
        /// <summary>
        /// Repay interest a/c
        /// </summary>
        [MaxLength(20)]
        public string? ZLEAN2 { get; set; }
        /// <summary>
        /// Repay interest a/c basic numbe
        /// </summary>
        [MaxLength(6)]
        public string? ZLANI { get; set; }
        /// <summary>
        /// Repay interest a/c suffix
        /// </summary>
        [MaxLength(3)]
        public string? ZLASI { get; set; }
        /// <summary>
        /// Repay interest a/c currency 
        /// </summary>
        [MaxLength(3)]
        public string? ZLCCYI { get; set; }
        /// <summary>
        /// Schedule advice?
        /// </summary>
        [MaxLength(1)]
        public string? ZLSAPZ { get; set; }
        /// <summary>
        /// Charge code 1
        /// </summary>
        [MaxLength(2)]
        public string? ZLCC1 { get; set; }
        /// <summary>
        /// Charge code 1
        /// </summary>
        [MaxLength(2)]
        public string? ZLCC2 { get; set; }
        /// <summary>
        /// Narrative 2 - 2
        /// </summary>
        [MaxLength(35)]
        public string? ZLNR22 { get; set; }
        /// <summary>
        /// Narrative on loan account?
        /// </summary>
        [MaxLength(1)]
        public string? ZLNDAZ { get; set; }
        /// <summary>
        /// Pegged
        /// </summary>
        [MaxLength(1)]
        public string ZLPEGZ { get; set; }      // Pegged?
        /// <summary>
        /// Repayment freqency
        /// </summary>
        [MaxLength(3)]
        public string ZLRPQ { get; set; }      // Repayment frequency?
        /// <summary>
        /// Account Office
        /// </summary>
        [MaxLength(3)]
        public string ZLACO { get; set; }
        /// <summary>
        /// Customer
        /// </summary>
        [MaxLength(6)]
        public string ZLCUS { get; set; }
        /// <summary>
        /// Interest frequency
        /// </summary>
        [MaxLength(3)]
        public string? ZLIFQ { get; set; }
    }
}
