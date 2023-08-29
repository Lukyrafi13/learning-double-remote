using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.EnumSandiBITypes;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
