using System;
using NewLMS.UMKM.Data.Entities;
using System.Collections.Generic;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfStages;

namespace NewLMS.UMKM.Data.Dto.SLIKs
{
    public class SLIKRequestResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public bool? ReadAndUnderstand { get; set; }
        public DateTime? ProcessDate { get; set; }
        public byte AdminVerified { get; set; }
        public double TotalCreditCard { get; set; }
        public double TotalLimitSlik { get; set; }
        public double TotalOtherUses { get; set; }
        public double TotalWorkingCapital { get; set; }
        public DateTime? InquiryDate { get; set; }

        public RfBranchResponse Branch { get; set; }
        public RfStageResponse RfStage { get; set; }
        public ICollection<SLIKRequestDebtorResponse> SLIKRequestDebtors { get; set; }
    }

    public class SLIKRequestTableResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public RfBranchResponse Branch { get; set; }
        public RfParameterDetailResponse RfOwnerCategory { get; set; }
        public string Fullname { get; set; }
        public ICollection<SLIKRequestDebtorResponse> SLIKRequestDebtors { get; set; }

    }
}

