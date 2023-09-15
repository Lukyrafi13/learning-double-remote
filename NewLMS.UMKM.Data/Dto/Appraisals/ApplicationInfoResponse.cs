using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.Users;
using NewLMS.UMKM.Data.Enums;
using System;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class ApplicationInfoResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public Guid StageId { get; set; }
        public EnumLoanApplicationStatus Status { get; set; }
        public string DataSource { get; set; }
        public string ProductId { get; set; }
        public Guid? ProspectId { get; set; }
        public int OwnerCategoryId { get; set; }
        public bool IsBusinessCycle { get; set; }
        public string BranchId { get; set; }
        public string BookingBranchId { get; set; }
        public string FullName { get; set; }
        public Guid? OwnerId { get; set; }

        public RfParameterDetailSimpleResponse RfOwnerCategory { get; set; }
        public RfBranchResponse RfBranch { get; set; }
        public RfBranchResponse RfBookingBranch { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public UserSimpleResponse Owner { get; set; }
        public ProspectEstimatedDateResponse Prospect { get; set; }
    }
}
