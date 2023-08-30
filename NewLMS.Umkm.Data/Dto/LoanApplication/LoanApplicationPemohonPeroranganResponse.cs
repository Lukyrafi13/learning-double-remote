using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationPemohonPeroranganResponse : LoanApplicationPemohonPerorangan
    {

        public Debtor DebtorResponse { get; set; }
        public DebtorCouple DebtorCoupleResponse { get; set; }
        public DebtorEmergency DebtorEmergencyResponse { get; set; }
    }
}
