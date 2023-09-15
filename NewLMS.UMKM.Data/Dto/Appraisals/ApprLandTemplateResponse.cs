using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class ApprLandTemplateResponse
    {
        public Guid ApprLandTemplateGuid { get; set; }
        public Guid AppraisalGuid { get; set; }

        public string ObjectType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public bool? ObjectStatus { get; set; }
        public string Inhabited { get; set; }
        public string CollateralOwner { get; set; }

        public SimpleResponse<Guid> EnvLocation { get; set; }
        public SimpleResponse<Guid> EnvGrowth { get; set; }
        public SimpleResponse<Guid> EnvDensity { get; set; }
        public SimpleResponse<Guid> EnvLandPrice { get; set; }

        public double? ResidentialArea { get; set; }
        public double? EducationArea { get; set; }
        public double? IndustryArea { get; set; }
        public double? ShopArea { get; set; }
        public double? OfficeArea { get; set; }
        public double? EmptyArea { get; set; }
        public SimpleResponse<Guid> ChangeToFuture { get; set; }
        public SimpleResponse<Guid> ResidentialMajority { get; set; }

        public SimpleResponse<Guid> EnvEaseOfAccess { get; set; }
        public SimpleResponse<Guid> EnvShopping { get; set; }
        public SimpleResponse<Guid> EnvSchool { get; set; }
        public SimpleResponse<Guid> EnvTransport { get; set; }
        public SimpleResponse<Guid> EnvRecreational { get; set; }
        public SimpleResponse<Guid> EnvCrimeSecurity { get; set; }
        public SimpleResponse<Guid> EnvFireSafety { get; set; }
        public SimpleResponse<Guid> EnvDisasterSafety { get; set; }

        public bool? Electric { get; set; }
        public double? ElectricPower { get; set; }
        public bool? CleanWater { get; set; }
        public bool? Phone { get; set; }
        public bool? Gass { get; set; }
        public bool? GarbageCollection { get; set; }
        public double? GarbageCollectionDistance { get; set; }
        public double? EntranceWay { get; set; }
        public SimpleResponse<Guid> EntranceWayType { get; set; }
        public double? EnvironmentWay { get; set; }
        public SimpleResponse<Guid> EnvironmentWayType { get; set; }
        public double? Drainase { get; set; }
        public SimpleResponse<Guid> DrainaseType { get; set; }
        public SimpleResponse<Guid> Sidewalk { get; set; }
        public SimpleResponse<Guid> StreetLight { get; set; }
        public string NorthernBoundary { get; set; }
        public string SouthernBoundary { get; set; }
        public string WesternBoundary { get; set; }
        public string EasternBoundary { get; set; }

        public SimpleResponse<Guid> Topografi { get; set; }
        public SimpleResponse<Guid> LandType { get; set; }
        public SimpleResponse<Guid> Greening { get; set; }
        public SimpleResponse<Guid> Arrangement { get; set; }
        public SimpleResponse<Guid> WaterDisposal { get; set; }
        public SimpleResponse<Guid> FloodRisk { get; set; }
        public SimpleResponse<Guid> FireRisk { get; set; }
        public double? LandHeight { get; set; }
        public SimpleResponse<Guid> Skewer { get; set; }
        public bool? IsPublicBurial { get; set; }
        public double? PublicBurial { get; set; }
        public SimpleResponse<Guid> HighVoltage { get; set; }
        public double? LandWidth { get; set; }
        public double? LandLength { get; set; }

        public SimpleResponse<Guid> CertificateType { get; set; }
        public string CertficateNumber { get; set; }
        public string RegisteredName { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string MeasureLetterNo { get; set; }
        public string MeasureLetterDate { get; set; }
        public SimpleResponse<Guid> LandShape { get; set; }
        public double? LandAreaValue { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool? IsValidUntil { get; set; }
        public string Address { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public SimpleResponse<string> Provinsi { get; set; }
        public SimpleResponse<string> KabupatenKota { get; set; }
        public SimpleResponse<string> Kecamatan { get; set; }
        public SimpleResponseWithPostCode<string> Kelurahan { get; set; }
        public string Remarks { get; set; }
    }
}
