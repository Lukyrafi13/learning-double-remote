using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationSurvey
{
    public class LoanApplicationFieldSurveyPostRequest
    {
        public DateTime? SurveyDate { get; set; }
        public string SurveyorName { get; set; }
        public string VerifierName { get; set; }
        public string Informan { get; set; }
        public int? RelationsWithDebtorsId { get; set; }
        //Bentuk Badan Usaha
        public int? OwnerCategoryId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessPhone { get; set; }
        public int? BusinessLocationStatusId { get; set; }
        public int? YearStandingBusiness { get; set; }
        public int? MonthStandingBusiness { get; set; }
        public int? NumberOfEmployees { get; set; }
        public int? NumberOfBranches { get; set; }
        //Bidang Usaha
        public string BusinessFieldKURId { get; set; }
        public bool AddressSameAsDebtor { get; set; }
        public string SurveyAddress { get; set; }
        public int? ZipCodeId { get; set; }
        public string ConclusionVerification { get; set; }
    }
}
