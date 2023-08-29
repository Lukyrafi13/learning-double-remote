using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOHUTANGPIHAKLAINs;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
