using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSkemaSIKPs;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
