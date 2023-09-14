using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.UMKM.Data.Dto.LoanApplicationRACs;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class AppraisalResponse : BaseResponse
    {
        public Guid AppraisalId { get; set; }
        public Guid LoanApplicationCollateralId { get; set; }
        public Boolean isInternal { get; set; }
        public Boolean isExternal { get; set; }
        public string Estimator { get; set; }
        public string Kjpp { get; set; }
        public string PropertyCategory { get; set; }
        public string AppraisalStatus { get; set; }
        public LoanApplicationCollateralResponse LoanApplicationCollateral { get; set; }
    }

    public class AppraisalSimpleResponse : BaseResponse
    {
        public Guid AppraisalId { get; set; }
        public Guid LoanApplicationCollateralId { get; set; }
        public Boolean isInternal { get; set; }
        public Boolean isExternal { get; set; }
        public string Estimator { get; set; }
        public string Kjpp { get; set; }
        public string PropertyCategory { get; set; }
        public string AppraisalStatus { get; set; }
    }

    public class LoanApplicationAppraisalTableResponse
    {
        public Guid LoanApplicationGuid { get; set; }
        public Guid LoanApplicationCollateralId { get; set; }
        public string LoanApplicationId { get; set; }
        public string DebtorName { get; set; }
        public string CreditSubProduct { get; set; }
        public string Collateral { get; set; }
        public DateTime EntryDate { get; set; }
    }

    public class LoanApplicationApprAsignmentResponse
    {
        public AppraisalSimpleResponse PropertyCategory { get; set; }
        public LoanApplicationCollateralResponse LoanApplicationCollateral { get; set; }
    }
}
