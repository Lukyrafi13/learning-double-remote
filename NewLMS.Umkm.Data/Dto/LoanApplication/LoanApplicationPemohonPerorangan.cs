using System;
using NewLMS.UMKM.Data.Dto.Debtors;

namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationPemohonPerorangan
    {
        public Guid Id { get; set; }
        
        public DebtorPostRequestDto Debtor { get; set; }

    }
}
