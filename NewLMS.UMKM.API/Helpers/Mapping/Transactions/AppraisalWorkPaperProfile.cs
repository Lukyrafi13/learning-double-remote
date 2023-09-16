using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers.MachineWorkPapers;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers.ShopAppartmentWorkPaper;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers.VehicleWorkPaper;
using NewLMS.UMKM.Data.Dto.AppraisalWorkPapers;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class AppraisalWorkPaperProfile : Profile
    {
        public AppraisalWorkPaperProfile()
        {
            CreateMap<ApprLandBuildingRequest, ApprWorkPaperLandBuildings>();
            CreateMap<ApprLandBuildingSummaryRequest, ApprWorkPaperLandBuildingSummaries>();
            CreateMap<ApprWorkPaperLandBuildings, ApprLandBuildingResponse>()
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.WilayahVillages))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.KotaKabupaten, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces))
            .ForMember(d => d.Offer, s => s.MapFrom(s => s.OfferFK))
            .ForMember(d => d.BuildingCategory, s => s.MapFrom(s => s.BuildingCategoryFK))
            .ForMember(d => d.LandDocument, s => s.MapFrom(s => s.LandDocumentFK))
            .ForMember(d => d.LandForm, s => s.MapFrom(s => s.LandFormFK))
            .ForMember(d => d.LandPosition, s => s.MapFrom(s => s.LandPositionFK))
            .ForMember(d => d.LandCondition, s => s.MapFrom(s => s.LandConditionFK))
            .ForMember(d => d.Topografi, s => s.MapFrom(s => s.TopografiFK));

            CreateMap<ApprMachineMarketWorkPaperPostRequest, ApprWorkPaperMachineMarkets>();
            CreateMap<ApprMachineMarketSummaryRequest, ApprWorkPaperMachineMarketSummaries>();
            CreateMap<ApprWorkPaperMachineMarkets, ApprMachineMarketWorkPaperResponse>()
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.WilayahVillages))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.Kota, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces))
            .ForMember(d => d.TransactionOffer, s => s.MapFrom(s => s.TransactionOfferFK));

            // CreateMap<ApprMachineMarketWorkPaperPostRequest, ApprWorkPaperMachineMarkets>();
            // CreateMap<ApprMachineMarketSummaryRequest, ApprWorkPaperMachineMarketSummaries>();
            CreateMap<ApprWorkPaperMachineCost, ApprWorkPaperMachineCostResponse>()
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.MachineTemplate.WilayahVillages))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.MachineTemplate.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.KotaKabupaten, s => s.MapFrom(s => s.MachineTemplate.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.MachineTemplate.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces))
            .ForMember(d => d.Address, s => s.MapFrom(s => s.MachineTemplate.Address))
            .ForMember(d => d.Rt, s => s.MapFrom(s => s.MachineTemplate.Rt))
            .ForMember(d => d.Rw, s => s.MapFrom(s => s.MachineTemplate.Rw))
            .ForMember(d => d.Merk, s => s.MapFrom(s => s.MachineTemplate.Manufacture))
            .ForMember(d => d.Capacity, s => s.MapFrom(s => s.MachineTemplate.Capacity))
            .ForMember(d => d.ProductionYear, s => s.MapFrom(s => s.MachineTemplate.ProductionYear))
            .ForMember(d => d.ManufacturerCountry, s => s.MapFrom(s => s.MachineTemplate.ManufacturerCountry));

            CreateMap<ApprShopApartmentRequest, ApprWorkPaperShopApartments>();
            CreateMap<ApprShopApartmentSummaryRequest, ApprWorkPaperShopApartmentSummaries>();
            CreateMap<ApprWorkPaperShopApartments, ApprShopApartmentResponse>()
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.WilayahVillages))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.KotaKabupaten, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces))
            .ForMember(d => d.Allotment, s => s.MapFrom(s => s.AllotmentFK))
            .ForMember(d => d.LandForm, s => s.MapFrom(s => s.LandFormFK))
            .ForMember(d => d.LandCondition, s => s.MapFrom(s => s.LandConditionFK))
            .ForMember(d => d.Ownership, s => s.MapFrom(s => s.OwnershipFK))
            .ForMember(d => d.DataType, s => s.MapFrom(s => s.DataTypeFK));

            CreateMap<ApprVehicleRequest, ApprWorkPaperVehicles>();
            CreateMap<ApprVehicleSummaryRequest, ApprWorkPaperVehicleSummaries>();
            CreateMap<ApprWorkPaperVehicles, ApprVehicleResponse>()
            .ForMember(d => d.Kelurahan, s => s.MapFrom(s => s.WilayahVillages))
            .ForMember(d => d.Kecamatan, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts))
            .ForMember(d => d.KotaKabupaten, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies))
            .ForMember(d => d.Provinsi, s => s.MapFrom(s => s.WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces))
            .ForMember(d => d.Transmission, s => s.MapFrom(s => s.TransmissionFK))
            .ForMember(d => d.DataType, s => s.MapFrom(s => s.DataTypeFK));

            CreateMap<ApprLiquidationPostRequest, ApprLiquidation>();
            CreateMap<ApprLiquidation, ApprLiquidationResponse>()
            .ForMember(d => d.LiquidationType, s => s.MapFrom(s => s.MLiquidationItem.MLiquidation))
            .ForMember(d => d.LiquidationItem, s => s.MapFrom(s => s.MLiquidationItem))
            .ForMember(d => d.LiquidationOption, s => s.MapFrom(s => s.MLiquidationOption));

            CreateMap<ApprWorkPaperLandBuildingSummaries, ApprWorkPaperLandBuildingHeaderResponse>();
            CreateMap<ApprWorkPaperMachineMarketSummaries, ApprWorkPaperMachineMarketHeaderResponse>();
            CreateMap<ApprWorkPaperShopApartmentSummaries, ApprWorkPaperShopApartmentHeaderResponse>();
            CreateMap<ApprWorkPaperVehicleSummaries, ApprWorkPaperVehicleHeaderResponse>();
        }
    }
}
