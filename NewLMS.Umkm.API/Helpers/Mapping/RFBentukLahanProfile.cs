using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFBentukLahans;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFBentukLahanProfile : Profile
    {
        public RFBentukLahanProfile()
        {
            CreateMap<RFBentukLahanPostRequestDto, RFBentukLahan>();
            CreateMap<RFBentukLahanPutRequestDto, RFBentukLahan>();
            CreateMap<RFBentukLahanResponseDto, RFBentukLahan>().ReverseMap();
        }
    }
}