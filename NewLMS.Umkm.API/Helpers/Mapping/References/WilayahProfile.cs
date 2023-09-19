using AutoMapper;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.References
{
    public class WilayahProfile : Profile
    {
        public WilayahProfile()
        {
            CreateMap<WilayahProvinces, SimpleResponse<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Code))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.Name));
            CreateMap<WilayahRegencies, SimpleResponse<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Code))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.Name));
            CreateMap<WilayahDistricts, SimpleResponse<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Code))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.Name));
            CreateMap<WilayahVillages, SimpleResponse<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Code))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.Name));
            CreateMap<WilayahVillages, SimpleResponseWithPostCode<string>>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Code))
            .ForMember(d => d.Description, s => s.MapFrom(s => s.Name))
            .ForMember(d => d.PostCode, s => s.MapFrom(s => s.PostCode));
        }
    }
}
