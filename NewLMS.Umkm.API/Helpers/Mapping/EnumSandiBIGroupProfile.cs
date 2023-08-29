using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.EnumSandiBIGroups;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class EnumSandiBIGroupProfile : Profile
    {
        public EnumSandiBIGroupProfile()
        {
            CreateMap<EnumSandiBIGroupPostRequestDto, EnumSandiBIGroup>();
            CreateMap<EnumSandiBIGroupPutRequestDto, EnumSandiBIGroup>();
            CreateMap<EnumSandiBIGroupResponseDto, EnumSandiBIGroup>().ReverseMap();
        }
    }
}
