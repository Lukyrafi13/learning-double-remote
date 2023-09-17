using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalMachine
{
    public class ApprMachineTemplatePostRequest
    {
        public Guid AppraisalGuid { get; set; }
        public string ObjectType { get; set; }
        public string VehicleType { get; set; }
        public string Manufacture { get; set; }
        public string Capacity { get; set; }
        public string ProductionYear { get; set; }
        public string ManufacturerCountry { get; set; }
        public string MachineNo { get; set; }
        public string ChassisNo { get; set; }
        public string InvoiceNo { get; set; }
        public string NameOnInvoice { get; set; }
        public string Storage { get; set; }
        public string Size { get; set; }
        public string PhysicalCondition { get; set; }
        public string FunctionCondition { get; set; }
        public string UsageTime { get; set; }
        public string Installation { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public string Overhaul { get; set; }
        public string PeriodicService { get; set; }

        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        // public int? ZipCodeId { get; set; }
        public string AddressReference { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Remarks { get; set; }
    }
}
