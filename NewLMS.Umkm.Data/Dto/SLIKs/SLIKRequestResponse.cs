using System;
using NewLMS.Umkm.Data.Entities;
using System.Collections.Generic;
using NewLMS.Umkm.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfStages;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.RfProducts;

namespace NewLMS.Umkm.Data.Dto.SLIKs
{
    public class SLIKRequestResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public bool? ReadAndUnderstand { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool AdminVerified { get; set; }
        public double TotalCreditCard { get; set; }
        public double TotalLimitSlik { get; set; }
        public double TotalOtherUses { get; set; }
        public double TotalWorkingCapital { get; set; }
        public DateTime? InquiryDate { get; set; }

        public SLIKInfoResponse Info { get; set; }
        public LoanApplicationBaseTabResponse LoanApplication { get; set; }
        public RfParameterDetailResponse RfOwnerCategory { get; set; }
        public RfBranchResponse Branch { get; set; }
        public RfStageResponse RfStage { get; set; }
        public ICollection<SLIKRequestDebtorResponse> SLIKRequestDebtors { get; set; }
    }

    public class SLIKInfoResponse
    {
        public RfBranchResponse BookingBranch { get; set; }
        public RfParameterDetailResponse OwnerCategory { get; set; }
        public string AccountOfficer { get; set; }
        public string LoanApplicationId { get; set; }
        public RfProductResponse RfProduct { get; set; }
        public string Fullname { get; set; }
        public string NoIdentity { get; set; }
        public string NPWP { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class SLIKRequestTableResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public RfBranchResponse Branch { get; set; }
        public RfParameterDetailResponse RfOwnerCategory { get; set; }
        public string ApplicationStatus { get; set; }
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<SLIKRequestDebtorResponse> SLIKRequestDebtors { get; set; }

    }
}

