using System;
using NewLMS.Umkm.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Dto.RfProducts;

namespace NewLMS.Umkm.Data.Dto.LoanApplications
{
    public class LoanApplicationInfoResponse
    {
        public string LoanApplicationId { get; set; }
        public string DebtorName { get; set; }
        public RfBranchResponse RfBookingBranch { get; set; }
        public string AccountOfficerName { get; set; }
        public RfProductResponse RfProduct { get; set; }
    }
}

