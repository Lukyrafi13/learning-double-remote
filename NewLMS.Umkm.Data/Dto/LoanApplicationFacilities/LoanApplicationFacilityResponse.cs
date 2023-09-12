using System;
using NewLMS.UMKM.Data.Dto.RfLoanPurpose;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfSubProducts;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data.Dto.RfTenor;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationFacilities
{
    public class LoanApplicationFacilityResponse : BaseResponse
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

        public virtual RfParameterDetailSimpleResponse ApplicationType { get; set; }
        public virtual RfParameterDetailSimpleResponse NatureOfCredit { get; set; }
        public virtual RfLoanPurposeSimpleResponse LoanPurpose { get; set; }
        public virtual RfTenorSimpleResponse RfTenor { get; set; }
        public virtual RfSubProductSimpleResponse RfSubProduct { get; set; }
        public virtual RfSectorLBU3Response RfSectorLBU3 { get; set; }
    }
}

