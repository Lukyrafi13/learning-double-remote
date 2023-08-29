using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Domain.Dwh.Entities
{
    public class COLLATERAL
    {
        // [Key]
        public string KODE_REGISTER_AGUNAN {get;set;}
        public string CIF_MNEMONIC {get;set;}
        public string BRANCH_MNEMONIC {get;set;}
        public string DEAL_TYPE {get;set;}
        public string DEAL_REF {get;set;}
        public string COLLATERAL_TYPE {get;set;}
        public string COLLATERAL_REF {get;set;}
        public DateTime? LAST_REVIEW_DATE {get;set;}
        public DateTime? COLL_EXPIRY_DATE {get;set;}
        public double MARKET_PRICE {get;set;}
        public int BANK_VALUE {get;set;}
        public int INSR_VALUE {get;set;}
        public string DEPARTEMENT_CODE {get;set;}
        public string REVIEW_FREQ {get;set;}
        public string CCY {get;set;}
        public DateTime BUSS_DATE {get;set;}
        public DateTime START_DATE {get;set;}
        public DateTime MATURITY_DATE {get;set;}
        public double PLAFOND {get;set;}
        public int OUTSTANDING {get;set;}
        public string COLLECT {get;set;}
        public double PLAFOND_ORI {get;set;}
        public string PENILAI {get;set;}
        public int SCORING {get;set;}
        public int DATE_REVIEW {get;set;}
        public string PRECENT_AGUNAN {get;set;}
        public double NILAI_YDP {get;set;}
        public double PPAP {get;set;}
    }
}