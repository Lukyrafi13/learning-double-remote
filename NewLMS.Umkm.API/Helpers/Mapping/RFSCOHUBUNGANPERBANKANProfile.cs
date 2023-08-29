using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOHUBUNGANPERBANKANs;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSCOHUBUNGANPERBANKANProfile : Profile
    {
        public RFSCOHUBUNGANPERBANKANProfile()
        {
            CreateMap<RFSCOHUBUNGANPERBANKANPostRequestDto, RFSCOHUBUNGANPERBANKAN>();
            CreateMap<RFSCOHUBUNGANPERBANKANPutRequestDto, RFSCOHUBUNGANPERBANKAN>();
            CreateMap<RFSCOHUBUNGANPERBANKANResponseDto, RFSCOHUBUNGANPERBANKAN>().ReverseMap();
        }
    }
}
