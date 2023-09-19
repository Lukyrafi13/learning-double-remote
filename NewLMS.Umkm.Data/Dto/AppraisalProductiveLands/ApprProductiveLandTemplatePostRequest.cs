using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalProductiveLands
{
    public class ApprProductiveLandTemplatePostRequest
    {
        public Guid AppraisalGuid { get; set; }
        public string ObjectType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string CollateralOwner { get; set; }
        public Boolean Inhabited { get; set; }
        public Boolean IsHaveBuilding { get; set; }
        public string InhabitedBy { get; set; }

        public Boolean Electric { get; set; }
        public Boolean CleanWater { get; set; }
        public Boolean Phone { get; set; }
        public Boolean Gas { get; set; }
        public Boolean GarbageCollection { get; set; }
        public Boolean Irrigation { get; set; }
        public string Entrance { get; set; }
        public string Driveway { get; set; }
        public string Drainase { get; set; }
        public string EnvDrainase { get; set; }
        public string NorthernBoundary { get; set; }
        public string SouthernBoundary { get; set; }
        public string WesternBoundary { get; set; }
        public string EasternBoundary { get; set; }

        public string EnvLocation { get; set; }
        public string EnvGrowth { get; set; }
        public string EnvDensity { get; set; }
        public string EnvComodity { get; set; }
        public string EnvEaseOfAccess { get; set; }
        public string EnvWaterFacilities { get; set; }
        public string EnvWaterQuality { get; set; }
        public string EnvTransport { get; set; }
        public string EnvDisasterSafety { get; set; }
        public string EnvChangesFutureUse { get; set; }
        public string EnvMajorityOwnership { get; set; }


        public string CertficateNumber { get; set; }
        public string RegisteredName { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string MeasureLetterNo { get; set; }
        public string MeasureLetterDate { get; set; }
        public string LandShape { get; set; }
        public string LandAreaValue { get; set; }
        public string Address { get; set; }

        public int? ZipCodeId { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string Topografi { get; set; }
        public string LandType { get; set; }
        public string Greening { get; set; }
        public string Arrangement { get; set; }
        public string WaterDisposal { get; set; }
        public string FloodRisk { get; set; }
        public string FireRisk { get; set; }
        public string LandHeight { get; set; }
        public string HighVoltage { get; set; }
        public string LandWidth { get; set; }
        public string LandLength { get; set; }
        public Boolean PublicBurial { get; set; }
        public string Remarks { get; set; }
        public string ElectricNetwork { get; set; }
        public string EnvRoad { get; set; }
        public string EnvCertificateType { get; set; }
        public string EnvPublicBurial { get; set; }
        public string Residential { get; set; }
        public string Farm { get; set; }
        public string Plantation { get; set; }
        public string Empty { get; set; }
        public DateTime? ValidUntil { get; set; }
        public Boolean Lifetime { get; set; }
        public string Skewer { get; set; }
        public string GarbageCollectionDistance { get; set; }
        public string EnvEntrance { get; set; }
    }
}
