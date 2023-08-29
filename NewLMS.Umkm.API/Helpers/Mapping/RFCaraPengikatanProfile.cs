using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFCaraPengikatans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFCaraPengikatanProfile : Profile
    {
        public RFCaraPengikatanProfile()
        {
            CreateMap<RFCaraPengikatanPostRequestDto, RFCaraPengikatan>();
            CreateMap<RFCaraPengikatanPutRequestDto, RFCaraPengikatan>();
            CreateMap<RFCaraPengikatanResponseDto, RFCaraPengikatan>().ReverseMap();
        }
    }
}