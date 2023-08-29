using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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