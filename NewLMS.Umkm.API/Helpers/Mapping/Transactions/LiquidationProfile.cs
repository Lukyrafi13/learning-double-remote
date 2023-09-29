using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LiquidationProfile : Profile
    {
        public LiquidationProfile()
        {
            CreateMap<MLiquidationOption, SimpleResponseWithScore<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.OptionId))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.OptionDesc))
            .ForMember(d => d.Score, s => s.MapFrom(s => s.OptionWeight));

            CreateMap<MLiquidation, SimpleResponse<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.TypeId))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.TypeDesc));

            CreateMap<MLiquidationItem, SimpleResponseWithScore<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.ItemId))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.ItemDesc))
            .ForMember(d => d.Score, s => s.MapFrom(s => s.ItemWeight));
        }
    }
}
