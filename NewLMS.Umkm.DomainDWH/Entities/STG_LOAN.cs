using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Domain.Dwh.Entities
{
    public class STG_LOAN
    {
        public DateTime BUSS_DATE { get; set; }
        public string CIF { get; set; }
        public string SUFFIX { get; set; }
        public string DEAL_REF { get; set; }
        public string CUST_SHORT_NAME { get; set; }
        public string BRANCH { get; set; }
        public string DEAL_TYPE { get; set; }
        public string CCY { get; set; }
        public string ACCOUNT_STATUS { get; set; }
        public string ACCOUNT_RELATED { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime MATURITY_DATE { get; set; }
        public DateTime LAST_TRX_DATE { get; set; }
        public decimal TENOR { get; set; }
        public decimal PLAFOND { get; set; }
        public decimal PLAFOND_FCCY { get; set; }
        public decimal OUTSTANDING { get; set; }
        public decimal OUTSTANDING_FCCY { get; set; }
        public decimal AVG_OUTSTANDING { get; set; }
        public decimal KONSTAN_PAYMENT { get; set; }
        public decimal INT_ACCRUED { get; set; }
        public decimal INT_RATE { get; set; }
        public string COLLECT { get; set; }
        public decimal PASTDUE_DAYS { get; set; }
        public decimal PASTDUE_INTEREST { get; set; }
        public decimal PASTDUE_PRINCIPAL { get; set; }
        public decimal FINAL_PAYMENT { get; set; }
        public decimal FEE_ADM { get; set; }
        public decimal FEE_COMMISION { get; set; }
        public decimal FEE_INSURANCE { get; set; }
        public DateTime SCHEDULE_DATE { get; set; }
        public decimal TOTAL_INTEREST { get; set; }
        public string RELATED { get; set; }
        public DateTime LAST_PAY_INT_DATE { get; set; }
        public DateTime LAST_PAY_PRINCIPAL_DATE { get; set; }
        public DateTime NEXT_SCHEDULE_DATE { get; set; }
        public decimal NEXT_SCHEDULE_PRINCIPAL_AMOUNT { get; set; }
        public decimal NEXT_SCHEDULE_INTEREST_AMOUNT { get; set; }
        public decimal AKUM_BALANCE { get; set; }
        public decimal AKUM_DAY { get; set; }
        public decimal PENALTY_INT { get; set; }
        public decimal PENALTY_PRI { get; set; }
        public DateTime LAST_PENALTY_DATE { get; set; }
        public decimal PAST_DUE_DAYS_I { get; set; }
        public DateTime ORI_MATURITY_DATE { get; set; }
        public decimal ORIGINAL_PLAFOND { get; set; }
        public DateTime CONTRACT_DATE { get; set; }
        public DateTime START_DATE_EQ { get; set; }
        public string REPAYMENT_METHOD { get; set; }
        public decimal LAST_CYCLE_INTEREST { get; set; }
        public string IDB { get; set; }
        public string INT_PREQ { get; set; }
        public string COMMITEMENT_REF { get; set; }
        public string NON_ACCRUAL_DATE { get; set; }
        public DateTime NEXT_ROLEOVER_DATE { get; set; }
    }
}
