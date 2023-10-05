using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprVehicleTemplate : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprVehicleTemplateGuid { get; set; }

        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }
        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }

        public string ObjectType { get; set; }
        public string VehicleType { get; set; }
        public string Manufacture { get; set; }
        public string ModelType { get; set; }

        [ForeignKey(nameof(RfOwnershipStatus))]
        public int? OwnershipStatus { get; set; }
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

        public virtual RfParameterDetail RfOwnershipStatus { get; set; }
    }
}
