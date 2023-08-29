using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.EnumSandiBIGroups;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
