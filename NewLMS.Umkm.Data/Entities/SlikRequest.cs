using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class SlikRequest : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        [ForeignKey(nameof(Branch))]
        public string BranchCode { get; set; }
        public string Comment { get; set; }
        public bool? ReadAndUnderstand { get; set; }
        public int ProcessStatus { get; set; }
        public DateTime? ProcessDate { get; set; }
        public byte AdminVerified { get; set; }
        public double TotalCreditCard => GetTotal("credit");
        public double TotalLimitSlik => TotalCreditCard + TotalOtherUses + TotalWorkingCapital;
        public double TotalOtherUses => GetTotal("other");
        public double TotalWorkingCapital => GetTotal("working");
        public DateTime? InquiryDate { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public RfBranch Branch { get; set; }
        public ICollection<SlikCreditHistory> SlikCreditHistories { get; set; }
        public ICollection<SlikRequestObject> SlikRequestObjects { get; set; }

        private double GetTotal(string type)
        {
            var totalOtherUses = 0.00;
            var totalWorkingCapitals = 0.00;
            var totalCreditCard = 0.00;
            foreach (var SlikCreditHistory in SlikCreditHistories??new List<SlikCreditHistory>())
            {
                if (SlikCreditHistory.RfCreditType.Code == "P05")
                {
                    totalCreditCard += SlikCreditHistory.PlafondLimit;
                }
                else
                {
                    if (SlikCreditHistory.RfSandiBIApplicationTypeClass?.BI_CODE == "1" &&
                SlikCreditHistory.RfSandiBIApplicationTypeClass?.BI_GROUP == "09")
                    {
                        totalWorkingCapitals += SlikCreditHistory.PlafondLimit;

                    }
                    else if (SlikCreditHistory.RfSandiBIApplicationTypeClass?.BI_CODE != null &&
                SlikCreditHistory.RfSandiBIApplicationTypeClass?.BI_GROUP != null)
                    {
                        totalOtherUses += SlikCreditHistory.PlafondLimit;

                    }
                }
            }

            return type == "credit"?totalCreditCard : type == "working" ? totalWorkingCapitals : totalOtherUses;
        }
    }
}