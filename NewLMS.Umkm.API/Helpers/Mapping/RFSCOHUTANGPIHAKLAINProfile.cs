using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOHUTANGPIHAKLAINs;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSCOHUTANGPIHAKLAINProfile : Profile
    {
        public RFSCOHUTANGPIHAKLAINProfile()
        {
            CreateMap<RFSCOHUTANGPIHAKLAINPostRequestDto, RFSCOHUTANGPIHAKLAIN>();
            CreateMap<RFSCOHUTANGPIHAKLAINPutRequestDto, RFSCOHUTANGPIHAKLAIN>();
            CreateMap<RFSCOHUTANGPIHAKLAINResponseDto, RFSCOHUTANGPIHAKLAIN>().ReverseMap();
        }
    }
}
