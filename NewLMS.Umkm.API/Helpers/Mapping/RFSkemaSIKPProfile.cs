using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSkemaSIKPs;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSkemaSIKPProfile : Profile
    {
        public RFSkemaSIKPProfile()
        {
            CreateMap<RFSkemaSIKPPostRequestDto, RFSkemaSIKP>();
            CreateMap<RFSkemaSIKPPutRequestDto, RFSkemaSIKP>();
            CreateMap<RFSkemaSIKPResponseDto, RFSkemaSIKP>().ReverseMap();
        }
    }
}
