using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprLandTemplates : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprLandTemplateGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }

        /* Start of Obyek sub-menu */
        public string ObjectType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public bool? ObjectStatus { get; set; }
        public string Inhabited { get; set; }
        public string CollateralOwner { get; set; }
        /* End */

        /* Start of Lingkungan sub-menu */
        [ForeignKey(nameof(EnvLocationFK))]
        public Guid? EnvLocation { get; set; }
        [ForeignKey(nameof(EnvGrowthFK))]
        public Guid? EnvGrowth { get; set; }
        [ForeignKey(nameof(EnvDensityFK))]
        public Guid? EnvDensity { get; set; }
        [ForeignKey(nameof(EnvLandPriceFK))]
        public Guid? EnvLandPrice { get; set; }
        /* End */

        /* Start of Kawasan sub-menu */
        public double? ResidentialArea { get; set; }
        public double? EducationArea { get; set; }
        public double? IndustryArea { get; set; }
        public double? ShopArea { get; set; }
        public double? OfficeArea { get; set; }
        public double? EmptyArea { get; set; }
        [ForeignKey(nameof(ChangeToFutureFK))]
        public Guid? ChangeToFuture { get; set; }
        [ForeignKey(nameof(ResidentialMajorityFK))]
        public Guid? ResidentialMajority { get; set; }
        /* End */

        /* Start of Analisa Lingkungan sub-menu */
        [ForeignKey(nameof(EnvEaseOfAccessFK))]
        public Guid? EnvEaseOfAccess { get; set; }
        [ForeignKey(nameof(EnvShoppingFK))]
        public Guid? EnvShopping { get; set; }
        [ForeignKey(nameof(EnvSchoolFK))]
        public Guid? EnvSchool { get; set; }
        [ForeignKey(nameof(EnvTransportFK))]
        public Guid? EnvTransport { get; set; }
        [ForeignKey(nameof(EnvRecreationalFK))]
        public Guid? EnvRecreational { get; set; }
        [ForeignKey(nameof(EnvCrimeSecurityFK))]
        public Guid? EnvCrimeSecurity { get; set; }
        [ForeignKey(nameof(EnvFireSafetyFK))]
        public Guid? EnvFireSafety { get; set; }
        [ForeignKey(nameof(EnvDisasterSafetyFK))]
        public Guid? EnvDisasterSafety { get; set; }
        /* End */

        /* Start of Fasilitas sub-menu */
        public bool? Electric { get; set; }
        public string ElectricPower { get; set; }
        public bool? CleanWater { get; set; }
        public bool? Phone { get; set; }
        public bool? Gass { get; set; }
        public bool? GarbageCollection { get; set; }
        public double? GarbageCollectionDistance { get; set; }
        public double? EntranceWay { get; set; }
        [ForeignKey(nameof(EntranceWayTypeFK))]
        public Guid? EntranceWayType { get; set; }
        public double? EnvironmentWay { get; set; }
        [ForeignKey(nameof(EnvironmentWayTypeFK))]
        public Guid? EnvironmentWayType { get; set; }
        public double? Drainase { get; set; }
        [ForeignKey(nameof(DrainaseTypeFK))]
        public Guid? DrainaseType { get; set; }
        [ForeignKey(nameof(SidewalkFK))]
        public Guid? Sidewalk { get; set; }
        [ForeignKey(nameof(StreetLightFK))]
        public Guid? StreetLight { get; set; }
        public string NorthernBoundary { get; set; }
        public string SouthernBoundary { get; set; }
        public string WesternBoundary { get; set; }
        public string EasternBoundary { get; set; }
        /* End */

        /* Start of Gambaran Umum Site sub-menu */
        [ForeignKey(nameof(TopografiFK))]
        public Guid? Topografi { get; set; }
        [ForeignKey(nameof(LandTypeFK))]
        public Guid? LandType { get; set; }
        [ForeignKey(nameof(GreeningFK))]
        public Guid? Greening { get; set; }
        [ForeignKey(nameof(ArrangementFK))]
        public Guid? Arrangement { get; set; }
        [ForeignKey(nameof(WaterDisposalFK))]
        public Guid? WaterDisposal { get; set; }
        [ForeignKey(nameof(FloodRiskFK))]
        public Guid? FloodRisk { get; set; }
        [ForeignKey(nameof(FireRiskFK))]
        public Guid? FireRisk { get; set; }
        public double? LandHeight { get; set; }
        [ForeignKey(nameof(SkewerFK))]
        public Guid? Skewer { get; set; }
        public bool? IsPublicBurial { get; set; }
        public double? PublicBurial { get; set; }
        [ForeignKey(nameof(HighVoltageFK))]
        public Guid? HighVoltage { get; set; }
        public double? LandWidth { get; set; }
        public double? LandLength { get; set; }
        /* End */

        /* Start of Other sub-menu */
        [ForeignKey(nameof(CertificateTypeFK))]
        public Guid? CertificateType { get; set; }
        public string CertficateNumber { get; set; }
        public string RegisteredName { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string MeasureLetterNo { get; set; }
        public string MeasureLetterDate { get; set; }
        [ForeignKey(nameof(LandShapeFK))]
        public Guid? LandShape { get; set; }
        public double? LandAreaValue { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool? IsValidUntil { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        [ForeignKey(nameof(WilayahVillages))]
        public string AddressReference { get; set; }
        public string Remark { get; set; }
        /* End */

        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public virtual WilayahVillages WilayahVillages { get; set; }
        public virtual Parameters EnvLocationFK { get; set; }
        public virtual Parameters EnvDensityFK { get; set; }
        public virtual Parameters EnvGrowthFK { get; set; }
        public virtual Parameters EnvLandPriceFK { get; set; }
        public virtual Parameters ChangeToFutureFK { get; set; }
        public virtual Parameters ResidentialMajorityFK { get; set; }
        public virtual Parameters EnvEaseOfAccessFK { get; set; }
        public virtual Parameters EnvShoppingFK { get; set; }
        public virtual Parameters EnvSchoolFK { get; set; }
        public virtual Parameters EnvTransportFK { get; set; }
        public virtual Parameters EnvRecreationalFK { get; set; }
        public virtual Parameters EnvCrimeSecurityFK { get; set; }
        public virtual Parameters EnvFireSafetyFK { get; set; }
        public virtual Parameters EnvDisasterSafetyFK { get; set; }
        public virtual Parameters EntranceWayTypeFK { get; set; }
        public virtual Parameters EnvironmentWayTypeFK { get; set; }
        public virtual Parameters DrainaseTypeFK { get; set; }
        public virtual Parameters SidewalkFK { get; set; }
        public virtual Parameters StreetLightFK { get; set; }
        public virtual Parameters TopografiFK { get; set; }
        public virtual Parameters LandTypeFK { get; set; }
        public virtual Parameters GreeningFK { get; set; }
        public virtual Parameters ArrangementFK { get; set; }
        public virtual Parameters WaterDisposalFK { get; set; }
        public virtual Parameters FloodRiskFK { get; set; }
        public virtual Parameters FireRiskFK { get; set; }
        public virtual Parameters SkewerFK { get; set; }
        public virtual Parameters HighVoltageFK { get; set; }
        public virtual Parameters CertificateTypeFK { get; set; }
        public virtual Parameters LandShapeFK { get; set; }
    }
}
