using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SlikRequest : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(App))]
        public Guid AppId { get; set; }

        [ForeignKey(nameof(Branch))]
        public string BranchCode { get; set; }
        public string Comment { get; set; }
        public bool? MembacaDanMemahami { get; set; }
        public int ProcessStatus { get; set; }
        public DateTime? ProcessDate { get; set; }
        public byte AdminVerified { get; set; }
        public double TotalCreditCard => GetTotal("credit");
        public double TotalLimitSlik => TotalCreditCard + TotalOtherUses + TotalWorkingCapital;
        public double TotalOtherUses => GetTotal("other");
        public double TotalWorkingCapital => GetTotal("working");
        public DateTime? InquiryDate { get; set; }
        public App App { get; set; }
        public RfBranches Branch { get; set; }
        public ICollection<SlikHistoryKredit> SlikHistoryKredits { get; set; }
        public ICollection<SlikRequestObject> SlikRequestObjects { get; set; }

        public bool? IsCheckingError { get; set; }
        public string CheckingErrorMessage { get; set; }
        public int? StatusCheckingDuplikasi { get; set; }

        public int Age => App?.Prospect?.AgeStage("4.2.1")??-1;
        private double GetTotal(string type)
        {
            var totalOtherUses = 0.00;
            var totalWorkingCapitals = 0.00;
            var totalCreditCard = 0.00;
            foreach (var SlikHistoryKredit in SlikHistoryKredits??new List<SlikHistoryKredit>())
            {
                if (SlikHistoryKredit.RfCreditType.Code == "P05")
                {
                    totalCreditCard += SlikHistoryKredit.PlafondLimit;
                }
                else
                {
                    if (SlikHistoryKredit.RfSandiBIApplicationTypeClass?.BI_CODE == "1" &&
                SlikHistoryKredit.RfSandiBIApplicationTypeClass?.BI_GROUP == "09")
                    {
                        totalWorkingCapitals += SlikHistoryKredit.PlafondLimit;

                    }
                    else if (SlikHistoryKredit.RfSandiBIApplicationTypeClass?.BI_CODE != null &&
                SlikHistoryKredit.RfSandiBIApplicationTypeClass?.BI_GROUP != null)
                    {
                        totalOtherUses += SlikHistoryKredit.PlafondLimit;

                    }
                }
            }

            return type == "credit"?totalCreditCard : type == "working" ? totalWorkingCapitals : totalOtherUses;
        }
    }
}