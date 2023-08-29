using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisLinkAges;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
