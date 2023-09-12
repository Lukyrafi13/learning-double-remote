using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationFacilities
{
    public class LoanApplicationFacilityRequest
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public int ApplicationTypeId { get; set; }
        public string LoanPurposeId { get; set; }
        public long SubmittedPlafond { get; set; }
        public string SubProductId { get; set; }
        public string TenorCode { get; set; }
        public string FacilityPurpose { get; set; }
        public string InstallmentType { get; set; }
        public double Interest { get; set; }
        public int NatureOfCreditId { get; set; }
        public long PrincipalInstallment { get; set; }
        public long InterestInstallment { get; set; }
        public string? SectorLBU3Code { get; set; }
    }
}

