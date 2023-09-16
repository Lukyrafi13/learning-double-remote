using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalWorkPapers
{
    public class ApprVehicleRequest
    {
        public int? DataNumber { get; set; }

        public Guid? DataType { get; set; }
        public string DataSource { get; set; }
        public string Address { get; set; }

        public string Rt { get; set; }

        public string Rw { get; set; }

        public string AddressReference { get; set; }
        public string PhoneNumber { get; set; }
        public string Offering { get; set; }
        public DateTime? DataDate { get; set; }
        public string Brand { get; set; }
        public string BrandType { get; set; }
        public string Year { get; set; }
        public string Condition { get; set; }
        public string BodyAccessories { get; set; }
        public string Color { get; set; }
        public string DomicileCity { get; set; }

        public Guid? Transmission { get; set; }
        public string Odometer { get; set; }



        /* FORM PENYESUAIAN */
        public decimal? PctDataDate { get; set; }
        public decimal? PctModelType { get; set; }
        public decimal? PctYear { get; set; }
        public decimal? PctCondition { get; set; }
        public decimal? PctBodyAccessories { get; set; }
        public decimal? PctColor { get; set; }
        public decimal? PctDomicileCity { get; set; }
        public decimal? PctTransmission { get; set; }
        public decimal? PctOdometer { get; set; }
        public double? Price { get; set; }
        public decimal? PctDiscount { get; set; }
        public decimal? TransactionIndication { get; set; }
        public decimal? TotalAdj { get; set; }
        public decimal? ResultAdj { get; set; }
        public decimal? AbsoluteAdj { get; set; }
        public decimal? Weight { get; set; }
        public decimal? SumIndicateValue { get; set; }

        public decimal? CurrDataDate { get; set; }
        public decimal? CurrModelType { get; set; }
        public decimal? CurrYear { get; set; }
        public decimal? CurrCondition { get; set; }
        public decimal? CurrBodyAccessories { get; set; }
        public decimal? CurrColor { get; set; }
        public decimal? CurrDomicileCity { get; set; }
        public decimal? CurrTransmission { get; set; }
        public decimal? CurrOdometer { get; set; }
        public double? CurrPrice { get; set; }
        public decimal? CurrTransactionIndication { get; set; }
        public decimal? CurrResultAdj { get; set; }
        public decimal? CurrSumIndicateValue { get; set; }
    }
}
