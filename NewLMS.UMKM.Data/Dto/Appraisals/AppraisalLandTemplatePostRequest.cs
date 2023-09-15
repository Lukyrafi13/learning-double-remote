using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class AppraisalLandTemplatePostRequest
    {
        public Guid AppraisalGuid { get; set; }

        public string ObjectType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public bool? ObjectStatus { get; set; }
        public string Inhabited { get; set; }
        public string CollateralOwner { get; set; }

        public Guid? EnvLocation { get; set; }
        public Guid? EnvGrowth { get; set; }
        public Guid? EnvDensity { get; set; }
        public Guid? EnvLandPrice { get; set; }

        public double? ResidentialArea { get; set; }
        public double? EducationArea { get; set; }
        public double? IndustryArea { get; set; }
        public double? ShopArea { get; set; }
        public double? OfficeArea { get; set; }
        public double? EmptyArea { get; set; }
        public Guid? ChangeToFuture { get; set; }
        public Guid? ResidentialMajority { get; set; }

        public Guid? EnvEaseOfAccess { get; set; }
        public Guid? EnvShopping { get; set; }
        public Guid? EnvSchool { get; set; }
        public Guid? EnvTransport { get; set; }
        public Guid? EnvRecreational { get; set; }
        public Guid? EnvCrimeSecurity { get; set; }
        public Guid? EnvFireSafety { get; set; }
        public Guid? EnvDisasterSafety { get; set; }

        public bool? Electric { get; set; }
        public double? ElectricPower { get; set; }
        public bool? CleanWater { get; set; }
        public bool? Phone { get; set; }
        public bool? Gass { get; set; }
        public bool? GarbageCollection { get; set; }
        public double? GarbageCollectionDistance { get; set; }
        public double? EntranceWay { get; set; }
        public Guid? EntranceWayType { get; set; }
        public double? EnvironmentWay { get; set; }
        public Guid? EnvironmentWayType { get; set; }
        public double? Drainase { get; set; }
        public Guid? DrainaseType { get; set; }
        public Guid? Sidewalk { get; set; }
        public Guid? StreetLight { get; set; }
        public string NorthernBoundary { get; set; }
        public string SouthernBoundary { get; set; }
        public string WesternBoundary { get; set; }
        public string EasternBoundary { get; set; }

        public Guid? Topografi { get; set; }
        public Guid? LandType { get; set; }
        public Guid? Greening { get; set; }
        public Guid? Arrangement { get; set; }
        public Guid? WaterDisposal { get; set; }
        public Guid? FloodRisk { get; set; }
        public Guid? FireRisk { get; set; }
        public double? LandHeight { get; set; }
        public Guid? Skewer { get; set; }
        public bool? IsPublicBurial { get; set; }
        public double? PublicBurial { get; set; }
        public Guid? HighVoltage { get; set; }
        public double? LandWidth { get; set; }
        public double? LandLength { get; set; }

        public Guid? CertificateType { get; set; }
        public string CertficateNumber { get; set; }
        public string RegisteredName { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string MeasureLetterNo { get; set; }
        public string MeasureLetterDate { get; set; }
        public Guid? LandShape { get; set; }
        public double? LandAreaValue { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool? IsValidUntil { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string AddressReference { get; set; }
        public string Remarks { get; set; }
    }
}
