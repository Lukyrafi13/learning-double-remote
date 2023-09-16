using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class ApprMachineMarketWorkPaperResponse
    {
        /* FORM PERHITUNGAN PENILAIAN MESIN */
        public int? DataNumber { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public SimpleResponseWithPostCode<string> Kelurahan { get; set; }
        public SimpleResponse<string> Kecamatan { get; set; }
        public SimpleResponse<string> Kota { get; set; }
        public SimpleResponse<string> Provinsi { get; set; }
        public SimpleResponse<Guid> TransactionOffer { get; set; }
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
        public decimal? CurrPrice { get; set; }
    }
}
