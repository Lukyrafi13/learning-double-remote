using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data
{
    public class RfCompany : BaseEntity
    {
        [Key]
        [Required]
        public string CompId { get; set; }
        public string CompName { get; set; }
        public string Address { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string ZIPCode { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PhoneArea { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExt { get; set; }
        public string Email { get; set; }
        public string FaxArea { get; set; }
        public string FaxNumber { get; set; }
        public string CoreCode { get; set; }
        public double MaxRpc { get; set; }
        public bool Mou { get; set; }
        public double MaxLimit { get; set; }
        public int MaxTenor { get; set; }
        public int MaximumYearBeforeRetirement { get; set; }
        public string BranchId { get; set; }
        public string EscrowNo { get; set; }
        public bool RpcPortion { get; set; }
        public double Salaray { get; set; }
        public double Allowances { get; set; }
        public bool Active { get; set; }

        #region Column Temp
        public string Temp_CompId { get; set; }
        public string Temp_CompName { get; set; }
        public string Temp_Address { get; set; }
        public string Temp_RT { get; set; }
        public string Temp_RW { get; set; }
        public string Temp_ZIPCode { get; set; }
        public string Temp_Neighborhoods { get; set; }
        public string Temp_District { get; set; }
        public string Temp_City { get; set; }
        public string Temp_Province { get; set; }
        public string Temp_PhoneArea { get; set; }
        public string Temp_PhoneNumber { get; set; }
        public string Temp_PhoneExt { get; set; }
        public string Temp_Email { get; set; }
        public string Temp_FaxArea { get; set; }
        public string Temp_FaxNumber { get; set; }
        public string Temp_CoreCode { get; set; }
        public double Temp_MaxRpc { get; set; }
        public bool Temp_Mou { get; set; }
        public double Temp_MaxLimit { get; set; }
        public int Temp_MaxTenor { get; set; }
        public int Temp_MaximumYearBeforeRetirement { get; set; }
        public string Temp_BranchId { get; set; }
        public string Temp_EscrowNo { get; set; }
        public bool Temp_RpcPortion { get; set; }
        public double Temp_Salaray { get; set; }
        public double Temp_Allowances { get; set; }
        public bool Temp_Active { get; set; }
        #endregion

        #region Approval
        [MaxLength(100)]
        public string StatusChecker { get; set; }
        public bool? IsCheker { get; set; }
        public ApprovalStatus? IsApproved { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RequestType { get; set; }
        #endregion
    }

    public enum ApprovalStatus
    { 
        WaitingApproval,
        Approved,
        Rejected
    }

}
