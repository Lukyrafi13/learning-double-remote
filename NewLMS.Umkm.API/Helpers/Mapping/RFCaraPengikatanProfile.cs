using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFCaraPengikatans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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