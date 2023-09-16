using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprLandTemplateProfile : Profile
    {
        public ApprLandTemplateProfile()
        {
            CreateMap<ApprLandTemplates, ApprLandTemplateResponse>()
            .ForMember(d => d.EnvLocation, s => s.MapFrom(s => s.EnvLocationFK))
            .ForMember(d => d.EnvGrowth, s => s.MapFrom(s => s.EnvGrowthFK))
            .ForMember(d => d.EnvDensity, s => s.MapFrom(s => s.EnvDensityFK))
            .ForMember(d => d.EnvLandPrice, s => s.MapFrom(s => s.EnvLandPriceFK))

            .ForMember(d => d.ChangeToFuture, s => s.MapFrom(s => s.ChangeToFutureFK))
            .ForMember(d => d.ResidentialMajority, s => s.MapFrom(s => s.ResidentialMajorityFK))

            .ForMember(d => d.EnvEaseOfAccess, s => s.MapFrom(s => s.EnvEaseOfAccessFK))
            .ForMember(d => d.EnvShopping, s => s.MapFrom(s => s.EnvShoppingFK))
            .ForMember(d => d.EnvSchool, s => s.MapFrom(s => s.EnvSchoolFK))
            .ForMember(d => d.EnvTransport, s => s.MapFrom(s => s.EnvTransportFK))
            .ForMember(d => d.EnvRecreational, s => s.MapFrom(s => s.EnvRecreationalFK))
            .ForMember(d => d.EnvCrimeSecurity, s => s.MapFrom(s => s.EnvCrimeSecurityFK))
            .ForMember(d => d.EnvFireSafety, s => s.MapFrom(s => s.EnvFireSafetyFK))
            .ForMember(d => d.EnvDisasterSafety, s => s.MapFrom(s => s.EnvDisasterSafetyFK))

            .ForMember(d => d.EntranceWayType, s => s.MapFrom(s => s.EntranceWayTypeFK))
            .ForMember(d => d.EnvironmentWayType, s => s.MapFrom(s => s.EnvironmentWayTypeFK))
            .ForMember(d => d.DrainaseType, s => s.MapFrom(s => s.DrainaseTypeFK))
            .ForMember(d => d.Sidewalk, s => s.MapFrom(s => s.SidewalkFK))
            .ForMember(d => d.StreetLight, s => s.MapFrom(s => s.StreetLightFK))

            .ForMember(d => d.Topografi, s => s.MapFrom(s => s.TopografiFK))
            .ForMember(d => d.LandType, s => s.MapFrom(s => s.LandTypeFK))
            .ForMember(d => d.Greening, s => s.MapFrom(s => s.GreeningFK))
            .ForMember(d => d.Arrangement, s => s.MapFrom(s => s.ArrangementFK))
            .ForMember(d => d.WaterDisposal, s => s.MapFrom(s => s.WaterDisposalFK))
            .ForMember(d => d.FloodRisk, s => s.MapFrom(s => s.FloodRiskFK))
            .ForMember(d => d.FireRisk, s => s.MapFrom(s => s.FireRiskFK))
            .ForMember(d => d.Skewer, s => s.MapFrom(s => s.SkewerFK))
            .ForMember(d => d.HighVoltage, s => s.MapFrom(s => s.HighVoltageFK))

            .ForMember(d => d.CertificateType, s => s.MapFrom(s => s.CertificateTypeFK))
            .ForMember(d => d.LandShape, s => s.MapFrom(s => s.LandShapeFK))

            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces))
            .ForMember(d => d.KabupatenKota, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.WilayahVillages))
            .ForMember(d => d.Remarks, s => s.MapFrom(s => s.Remark));

            CreateMap<AppraisalLandTemplatePostRequest, ApprLandTemplates>()
            .ForMember(d => d.Remark, s => s.MapFrom(s => s.Remarks));
        }
    }
}
