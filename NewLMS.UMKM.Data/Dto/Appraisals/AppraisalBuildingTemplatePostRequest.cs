using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class AppraisalBuildingTemplatePostRequest
    {
        public Guid AppraisalGuid { get; set; }

        public string ObjectType { get; set; }          // New
        public DateTime? InspectionDate { get; set; }   // New
        public bool? ObjectStatus { get; set; }         // New
        public string Inhabited { get; set; }           // New
        public string CollateralOwner { get; set; }     // New

        public Guid? Pondation { get; set; }            // Update
        public Guid? Wall { get; set; }                 // Update
        public Guid? Floor { get; set; }                // Update
        public Guid? RoofTruss { get; set; }            // Update
        public Guid? Roof { get; set; }                 // Update
        public Guid? InnerWall { get; set; }            // Update
        public Guid? Sills { get; set; }                // Update
        public Guid? Plafond { get; set; }              // Update
        public Guid? ElectricConn { get; set; }         // Update
        public double? ElectricConnWatt { get; set; }
        public Guid? CleanWater { get; set; }           // Update
        public Guid? Phone { get; set; }                // Update
        public string PhoneNumber { get; set; }         // New
        public Guid? ArchitectShape { get; set; }
        public int? YearBuilt { get; set; }             // Update
        public int? RenovatedYear { get; set; }         // Update
        public bool? IsImb { get; set; }
        public string ImbNo { get; set; }
        public DateTime? ImbDate { get; set; }
        public double? ImbBasedArea { get; set; }         // New
        public double? RealMeasuringArea { get; set; }  // Update
        public double? AreaDifference { get; set; }     // New
        public double? YardToStreet { get; set; }       // Update
        public double? YardToFloor { get; set; }        // Update
        public Guid? BuildingCondition { get; set; }    // Update
        public Guid? YardCondition { get; set; }        // Update
        public Guid? Fence { get; set; }                // Update
        public string Remarks { get; set; }
    }
}
