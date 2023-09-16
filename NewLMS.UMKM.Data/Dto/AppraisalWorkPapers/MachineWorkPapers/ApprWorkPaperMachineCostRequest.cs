using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalWorkPapers.MachineWorkPapers
{
    public class ApprWorkPaperMachineCostRequest
    {
        public string DataSource { get; set; }
        // public string Address { get; set; }              // Dari Template Mesin
        // public string Rt { get; set; }                   // Dari Template Mesin
        // public string Rw { get; set; }                   // Dari Template Mesin
        // [ForeignKey(nameof(WilayahVillages))] 
        // public string WilayahVillageCode { get; set; }   // Dari Template Mesin
        public string PicPhoneNo { get; set; }
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
        public decimal? CurrMarketCostValue { get; set; }
        public double? PctLiquidationCostValue { get; set; }
        public decimal? LiquidationCostValue { get; set; }
    }
}
