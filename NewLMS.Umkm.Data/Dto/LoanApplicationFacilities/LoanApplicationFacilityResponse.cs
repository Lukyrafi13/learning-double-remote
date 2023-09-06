using System;
using NewLMS.UMKM.Data.Dto.RfLoanPurpose;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfSubProducts;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationFacilities
{
    public class LoanApplicationFacilityResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public long SubmittedPlafond { get; set; }
        public int LoanTerm { get; set; }
        public string FacilityPurpose { get; set; }
        public string InstallmentType { get; set; }
        public string Interest { get; set; }
        public long PrincipalInstallment { get; set; }
        public long InterestInstallment { get; set; }

        public virtual RfParameterDetailResponse ApplicationType { get; set; }
        public virtual RfParameterDetailResponse NatureOfCredit { get; set; }
        public virtual RfLoanPurposeResponse LoanPurpose { get; set; }
        public virtual RfSubProductResponse RfSubProduct { get; set; }
        public virtual RfSectorLBU3Response RfSectorLBU3 { get; set; }
    }
}

