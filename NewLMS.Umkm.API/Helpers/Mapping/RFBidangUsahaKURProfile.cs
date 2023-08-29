using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFBidangUsahaKURs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFBidangUsahaKURProfile : Profile
    {
        public RFBidangUsahaKURProfile()
        {
            CreateMap<RFBidangUsahaKURPostRequestDto, RFBidangUsahaKUR>();
            CreateMap<RFBidangUsahaKURPutRequestDto, RFBidangUsahaKUR>();
            CreateMap<RFBidangUsahaKURResponseDto, RFBidangUsahaKUR>().ReverseMap();
        }
    }
}