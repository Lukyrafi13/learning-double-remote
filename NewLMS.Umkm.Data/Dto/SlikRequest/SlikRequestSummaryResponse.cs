using System;
namespace NewLMS.UMKM.Data.Dto.SlikRequests
{
    public class SlikRequestSummaryResponse : SlikRequestSummaryPut
    {
        public double TotalCreditCard {get; set;}
        public double TotalLimitSlik {get; set;}
        public double TotalOtherUses {get; set;}
        public double TotalWorkingCapital {get; set;}
        public LoanApplication LoanApplication { get; set; }
    }
}
