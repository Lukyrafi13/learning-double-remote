using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.Data.Entities
{
    public class GeneratedFiles : BaseEntity
    {
        [Key]
        [Required]
        public Guid GeneratedFileGuid { get; set; }
        
        [ForeignKey(nameof(LoanApplications))]
        public Guid LoanApplicationGuid { get; set; }

        [ForeignKey(nameof(LoanApplicationCollateral))]
        public Guid? LoanApplicationCollateralGuid { get; set; }

        [ForeignKey(nameof(GeneratedFileGroups))]
        public Guid GeneratedFileGroupGuid { get; set; }
        
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }
        
        
        public virtual LoanApplication LoanApplications { get; set; }
        public virtual GeneratedFileGroups GeneratedFileGroups { get; set; }
        public virtual LoanApplicationCollateral LoanApplicationCollateral { get; set; }
    }
}