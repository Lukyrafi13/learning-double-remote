using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfAppTypes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfAppTypeProfile : Profile
    {
        public RfAppTypeProfile()
        {
            CreateMap<RfAppType, RfAppTypeResponseDto>().ReverseMap();
            CreateMap<RfAppTypePostRequestDto, RfAppType>();
            CreateMap<RfAppTypePutRequestDto, RfAppType>();
        }
    }
}