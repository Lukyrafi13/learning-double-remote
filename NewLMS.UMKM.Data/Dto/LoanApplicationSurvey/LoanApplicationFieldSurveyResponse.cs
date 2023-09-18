using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfBusinessFieldKUR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationSurvey
{
    public class LoanApplicationFieldSurveyResponse : BaseResponse
    {
        public Guid Id { get; set; }
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

        public virtual RfParameterDetailSimpleResponse RelationsWithDebtors { get; set; }
        public virtual RfParameterDetailSimpleResponse OwnerCategory { get; set; }
        public virtual RfParameterDetailSimpleResponse BusinessLocationStatus { get; set; }
        public virtual RfBusinessFieldKURSimpleResponse BusinessFieldKUR { get; set; }
        public virtual RfZipCodeResponse RfZipCode { get; set; }
    }
}
