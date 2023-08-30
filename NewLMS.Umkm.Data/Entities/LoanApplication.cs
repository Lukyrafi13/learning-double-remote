using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewLMS.UMKM.Data
{
    public class LoanApplication : BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]

        public string LoanApplicationId { get; set; }
        [ForeignKey(nameof(Prospect))]
        public Guid? ProspectId { get; set; }

        [ForeignKey(nameof(RfOwnerCategory))]
        public Guid? RfOwnerCategoryId { get; set; }

        // etc
        public string DataSource { get; set; }

        [MaxLength(16)]
        [ForeignKey(nameof(Debtor))]
        public string NoIdentity { get; set; }
        
        [ForeignKey(nameof(CompanyEntity))]
        public Guid? CompanyEntityGuid { get; set; }

        // Other stage
        public RfOwnerCategory RfOwnerCategory {get; set; }
        public Debtor Debtor {get; set; }
        public Prospect Prospect {get; set; }
        public CompanyEntity CompanyEntity {get; set; }
        public RfStage LatestStage => getCurrentStage();

        public ICollection<LoanApplicationStageLogs> LoanApplicationStageLogs { get; set; }

        public RfStage getCurrentStage(){
            RfStage result = null;

            if (LoanApplicationStageLogs == null){
                return result;
            }

            var latestLog = LoanApplicationStageLogs.OrderBy(x=>x.CreatedDate).ToList().Last();
            

            return latestLog.RfStage??result;
        }
    }
}