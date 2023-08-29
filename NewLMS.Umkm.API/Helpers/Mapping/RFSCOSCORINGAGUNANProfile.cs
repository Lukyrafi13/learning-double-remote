using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOSCORINGAGUNANs;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFSCOSCORINGAGUNANProfile : Profile
    {
        public RFSCOSCORINGAGUNANProfile()
        {
            CreateMap<RFSCOSCORINGAGUNANPostRequestDto, RFSCOSCORINGAGUNAN>();
            CreateMap<RFSCOSCORINGAGUNANPutRequestDto, RFSCOSCORINGAGUNAN>();
            CreateMap<RFSCOSCORINGAGUNANResponseDto, RFSCOSCORINGAGUNAN>().ReverseMap();
        }
    }
}
