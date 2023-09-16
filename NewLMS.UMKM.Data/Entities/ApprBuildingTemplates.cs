using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class ApprBuildingTemplates : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprEnvironmentGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }

        /* Start of Obyek sub-menu */
        public string ObjectType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public bool? ObjectStatus { get; set; }
        public string Inhabited { get; set; }
        public string CollateralOwner { get; set; }
        /* End */

        public double? TotalBuildingArea { get; set; }

        /* Start of Spesifikasi sub-menu */
        [ForeignKey(nameof(FoundationFK))]
        public Guid? Foundation { get; set; }
        [ForeignKey(nameof(WallFK))]
        public Guid? Wall { get; set; }
        [ForeignKey(nameof(FloorFK))]
        public Guid? Floor { get; set; }
        [ForeignKey(nameof(RoofTrussFK))]
        public Guid? RoofTruss { get; set; }
        [ForeignKey(nameof(RoofFK))]
        public Guid? Roof { get; set; }
        [ForeignKey(nameof(PlafondFK))]
        public Guid? Plafond { get; set; }
        [ForeignKey(nameof(InnerWallFK))]
        public Guid? InnerWall { get; set; }
        [ForeignKey(nameof(SillsFK))]
        public Guid? Sills { get; set; }
        [ForeignKey(nameof(ElectricConnFK))]
        public Guid? ElectricConn { get; set; }
        public double? ElectricConnWatt { get; set; }
        [ForeignKey(nameof(CleanWaterFK))]
        public Guid? CleanWater { get; set; }
        [ForeignKey(nameof(PhoneFK))]
        public Guid? Phone { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey(nameof(ArchitectShapeFK))]
        public Guid? ArchitectShape { get; set; }
        public int? YearBuilt { get; set; }
        public int? RenovatedYear { get; set; }
        public bool? IsImb { get; set; }
        public string ImbNo { get; set; }
        public DateTime? ImbDate { get; set; }
        public double? ImbBasedArea { get; set; }
        public double? RealMeasuringArea { get; set; }
        public double? AreaDifference { get; set; }
        public double? YardToStreet { get; set; }
        public double? YardToFloor { get; set; }
        [ForeignKey(nameof(BuildingConditionFK))]
        public Guid? BuildingCondition { get; set; }
        [ForeignKey(nameof(YardConditionFK))]
        public Guid? YardCondition { get; set; }
        [ForeignKey(nameof(FenceFK))]
        public Guid? Fence { get; set; }
        public string Remark { get; set; }
        /* End */

        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public virtual Parameters FoundationFK { get; set; }
        public virtual Parameters WallFK { get; set; }
        public virtual Parameters FloorFK { get; set; }
        public virtual Parameters RoofTrussFK { get; set; }
        public virtual Parameters RoofFK { get; set; }
        public virtual Parameters PlafondFK { get; set; }
        public virtual Parameters InnerWallFK { get; set; }
        public virtual Parameters SillsFK { get; set; }
        public virtual Parameters ElectricConnFK { get; set; }
        public virtual Parameters CleanWaterFK { get; set; }
        public virtual Parameters PhoneFK { get; set; }
        public virtual Parameters ArchitectShapeFK { get; set; }
        public virtual Parameters BuildingConditionFK { get; set; }
        public virtual Parameters YardConditionFK { get; set; }
        public virtual Parameters FenceFK { get; set; }
        public virtual ICollection<ApprBuildingFloors> ApprBuildingFloors { get; set; }
    }
}
