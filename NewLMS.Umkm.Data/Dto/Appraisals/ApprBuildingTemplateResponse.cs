using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class ApprBuildingTemplateResponse
    {
        public Guid ApprEnvironmentGuid { get; set; }
        public Guid AppraisalGuid { get; set; }

        public string ObjectType { get; set; }          // New
        public DateTime? InspectionDate { get; set; }   // New
        public bool? ObjectStatus { get; set; }         // New
        public string Inhabited { get; set; }           // New
        public string DebtorName { get; set; }
        public string SurveyorName { get; set; }
        public string CollateralOwner { get; set; }     // New

        public SimpleResponse<Guid> Pondation { get; set; }
        public SimpleResponse<Guid> Wall { get; set; }
        public SimpleResponse<Guid> Floor { get; set; }
        public SimpleResponse<Guid> RoofTruss { get; set; }
        public SimpleResponse<Guid> Roof { get; set; }
        public SimpleResponse<Guid> InnerWall { get; set; }
        public SimpleResponse<Guid> Sills { get; set; }
        public SimpleResponse<Guid> Plafond { get; set; }
        public SimpleResponse<Guid> ElectricConn { get; set; }
        public double? ElectricConnWatt { get; set; }
        public SimpleResponse<Guid> CleanWater { get; set; }
        public SimpleResponse<Guid> Phone { get; set; }
        public string PhoneNumber { get; set; }           // New
        public SimpleResponse<Guid> ArchitectShape { get; set; }
        public int? YearBuilt { get; set; }             // Update
        public int? RenovatedYear { get; set; }         // Update
        public bool? IsImb { get; set; }
        public string ImbNo { get; set; }
        public DateTime? ImbDate { get; set; }
        public double? ImbBasedArea { get; set; }         // New
        public double? RealMeasuringArea { get; set; }  // Update
        public double? YardToStreet { get; set; }       // Update
        public double? YardToFloor { get; set; }        // Update
        public SimpleResponse<Guid> BuildingCondition { get; set; }
        public SimpleResponse<Guid> YardCondition { get; set; }
        public SimpleResponse<Guid> Fence { get; set; }
        public string Remarks { get; set; }
    }
}
