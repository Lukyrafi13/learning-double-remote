using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprWorkPaperMachineCost : BaseEntity
    {
        [Key]
        public Guid ApprWorkPaperMachineCostGuid { get; set; }
        [ForeignKey(nameof(ApprWorkPaperMachineMarketSummaries))]
        public Guid ApprWorkPaperMachineMarketSummaryGuid { get; set; }

        [ForeignKey(nameof(MachineTemplate))]
        public Guid? ApprMachineTemplateGuid { get; set; }
        // public string Address { get; set; }              // Dari Template Mesin
        // public string Rt { get; set; }                   // Dari Template Mesin
        // public string Rw { get; set; }                   // Dari Template Mesin
        // [ForeignKey(nameof(WilayahVillages))] 
        // public string WilayahVillageCode { get; set; }   // Dari Template Mesin
        public string DataSource { get; set; }
        [MaxLength(20)]
        public string PicPhoneNo { get; set; }
        [MaxLength(20)]
        public string DistributorPhoneNo { get; set; }
        public string MachineType { get; set; }
        // public string Merk { get; set; }                 // Dari Template Mesin
        public string ModelType { get; set; }
        // public string Capacity { get; set; }             // Dari Template Mesin
        // public int? ProductionYear { get; set; }         // Dari Template Mesin
        public int? EconomicAge { get; set; }
        public string Condition { get; set; }
        // public string ManufacturerCountry { get; set; }  // Dari Template Mesin
        public decimal? InvoiceValue { get; set; }
        public double? PctDepreciation { get; set; }

        public virtual ApprMachineTemplate MachineTemplate { get; set; }
        public virtual ApprWorkPaperMachineMarketSummaries ApprWorkPaperMachineMarketSummaries { get; set; }
    }
}
