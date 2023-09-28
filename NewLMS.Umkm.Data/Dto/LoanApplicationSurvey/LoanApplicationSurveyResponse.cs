using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationBusiness;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycles;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeeds;
using NewLMS.Umkm.Data.Dto.RfSubProducts;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationSurvey
{
    public class LoanApplicationSurveyResponse
    {
        public LoanApplicationAppInfoSurveyResponse LoanApplicationInfo { get; set; }
        public LoanApplicationFieldSurveyResponse? LoanApplicationFieldSurvey { get; set; }
        public LoanApplicationVerificationBusinessResponse? LoanApplicationVerificationBusiness { get; set; }
        public LoanApplicationVerificationCycleResponse? LoanApplicationVerificationCycle { get; set; }
        public LoanApplicationVerificationNeedsResponse? LoanApplicationVerificationNeed { get; set; }
    }

    public class LoanApplicationSurveyTabRespone
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public DateTime RequestDate { get; set; }
        public string SlikStatus { get; set; }
        public string DebtorName { get; set; }
        public DateTime? DebtorDateOfBirth { get; set; }
    }

    public class LoanApplicationAppInfoSurveyResponse
    {
        public string Regency { get; set; }
        public string Branch { get; set; }
        public string AccountOfficer { get; set; }
        public string LoanApplicationId { get; set; }
        public string Product { get; set; }
        public string Name { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BookingOffice { get; set; }
        public bool IsBusinessCycle { get; set; }
        public RfSubProductSimpleResponse RfSubProduct { get; set; }

    }
}
