using System;
namespace NewLMS.Umkm.Data.Dto.SlikRequests
{
    public class SlikRequestSummaryResponse : SlikRequestSummaryPut
    {
        public double TotalCreditCard {get; set;}
        public double TotalLimitSlik {get; set;}
        public double TotalOtherUses {get; set;}
        public double TotalWorkingCapital {get; set;}
        public App App { get; set; }
    }
}
