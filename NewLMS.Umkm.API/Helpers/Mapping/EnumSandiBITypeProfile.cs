using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class EnumSandiBITypeProfile : Profile
    {
        public EnumSandiBITypeProfile()
        {
            CreateMap<EnumSandiBITypePostRequestDto, EnumSandiBIType>();
            CreateMap<EnumSandiBITypePutRequestDto, EnumSandiBIType>();
            CreateMap<EnumSandiBITypeResponseDto, EnumSandiBIType>().ReverseMap();
        }
    }
}
