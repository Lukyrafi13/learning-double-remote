using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalVehicle
{
    public class ApprVehicleTemplateResponse
    {
        public Guid ApprVehicleTemplateGuid { get; set; }
        public Guid AppraisalGuid { get; set; }
        public string ObjectType { get; set; }
        public string VehicleType { get; set; }
        public string Manufacture { get; set; }
        public string ModelType { get; set; }
        public string OwnershipStatus { get; set; }
        public string OwnerName { get; set; }
        public string DomicileCity { get; set; }
        public string MachineNo { get; set; }
        public string ChassisNo { get; set; }
        public string PlatNo { get; set; }
        public string BpkbNo { get; set; }
        public string BpkbName { get; set; }
        public string Color { get; set; }
        public string PaintCondition { get; set; }
        public string BodyCondition { get; set; }
        public string SuspensionCondition { get; set; }
        public string MachineCondition { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Mileage { get; set; }
        public string FeatureFunction { get; set; }
        public string PeriodicService { get; set; }
    }
}
