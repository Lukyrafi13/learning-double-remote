using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprMachineMarketWorkPaperPostRequest
    {
        /* FORM PERHITUNGAN PENILAIAN MESIN */
        public int? DataNumber { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string AddressReference { get; set; }

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
    }
}
