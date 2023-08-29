using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisLinkAges;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFJenisLinkAgeProfile : Profile
    {
        public RFJenisLinkAgeProfile()
        {
            CreateMap<RFJenisLinkAgePostRequestDto, RFJenisLinkAge>();
            CreateMap<RFJenisLinkAgePutRequestDto, RFJenisLinkAge>();
            CreateMap<RFJenisLinkAgeResponseDto, RFJenisLinkAge>().ReverseMap();
        }
    }
}
