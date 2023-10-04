using NewLMS.Umkm.Data.Dto.LoanApplicationBusinessInformations;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Dto.LoanApplicationRACs;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycles;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeeds;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts
{
    public class LoanApplicationAnalystReponse
    {
        public LoanApplicationAnalystAppInfoResponse LoanApplicationAnalystAppInfo { get; set; }
        public LoanApplicationRACsResponse? LoanApplicationRAC { get; set; }
        public LoanApplicationVerificationBusinessResponse? LoanApplicationVerificationBusiness { get; set; }
        public LoanApplicationVerificationCycleResponse? LoanApplicationVerificationCycle { get; set; }
        public LoanApplicationVerificationNeedsResponse? LoanApplicationVerificationNeeds { get; set; }
        public LoanApplicationBusinessInformationResponse? LoanApplicationBusinessInformation { get; set; }
        public LoanApplicationAnalystSLIKAdminTabResponse? SLIKAdmin { get; set; }
        //Hubungan Dengan Bank
        //Hasil Analisa
        //Informasi Lainya
        //Syarat Kredit
        //Complience Sheet
        //History
    }
}
