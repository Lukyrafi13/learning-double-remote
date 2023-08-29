using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOHUBUNGANPERBANKANs;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
