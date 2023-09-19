using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprWorkPaperMachineMarkets : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprWorkPaperMachineMarketGuid { get; set; }
        [ForeignKey(nameof(ApprWorkPaperMachineMarketSummaries))]
        public Guid ApprWorkPaperMachineMarketSummaryGuid { get; set; }

        [ForeignKey(nameof(MachineTemplate))]
        public Guid? ApprMachineTemplateGuid { get; set; }

        /* FORM PERHITUNGAN PENILAIAN MESIN */
        public int? DataNumber { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
        [MaxLength(5)]
        public string Rt { get; set; }
        [MaxLength(5)]
        public string Rw { get; set; }

        [ForeignKey(nameof(WilayahVillages))]
        public string AddressReference { get; set; }
        [ForeignKey(nameof(TransactionOfferFK))]
        public Guid? TransactionOffer { get; set; }
        public DateTime? DataDate { get; set; }
        public string MachineType { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string ProductionYear { get; set; }
        public string Condition { get; set; }
        public string ManufacturerCountry { get; set; }

        /* PENYESUAIAN */
        public double? PctDataDate { get; set; }
        public double? PctModelType { get; set; }
        public double? PctCapacity { get; set; }
        public double? PctYear { get; set; }
        public double? PctCondition { get; set; }
        public double? PctManufacurerCountry { get; set; }
        public double? PctDiscount { get; set; }
        public double? PctTotalAdjustment { get; set; }
        public double? PctAbsoluteAdjustment { get; set; }
        public double? PctWeight { get; set; }
        public decimal? CurrDataDate { get; set; }
        public decimal? CurrModelType { get; set; }
        public decimal? CurrCapacity { get; set; }
        public decimal? CurrYear { get; set; }
        public decimal? CurrCondition { get; set; }
        public decimal? CurrManufacurerCountry { get; set; }
        public decimal? CurrPrice { get; set; }
        public decimal? CurrTransactionIndicator { get; set; }
        public decimal? CurrValueAfterAdjustment { get; set; }
        public decimal? CurrAmountIndicator { get; set; }

        public virtual ApprMachineTemplate MachineTemplate { get; set; }
        public virtual ApprWorkPaperMachineMarketSummaries ApprWorkPaperMachineMarketSummaries { get; set; }
        public virtual WilayahVillages WilayahVillages { get; set; }
        public virtual Parameters TransactionOfferFK { get; set; }
    }
}
