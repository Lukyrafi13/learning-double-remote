using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFBentukLahans;

namespace NewLMS.UMKM.API.Helpers.Mapping

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