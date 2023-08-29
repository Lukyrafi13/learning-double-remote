using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOSCORINGAGUNANs;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
