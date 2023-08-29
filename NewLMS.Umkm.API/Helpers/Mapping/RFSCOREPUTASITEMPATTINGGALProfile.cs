using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSCOREPUTASITEMPATTINGGALProfile : Profile
    {
        public RFSCOREPUTASITEMPATTINGGALProfile()
        {
            CreateMap<RFSCOREPUTASITEMPATTINGGALPostRequestDto, RFSCOREPUTASITEMPATTINGGAL>();
            CreateMap<RFSCOREPUTASITEMPATTINGGALPutRequestDto, RFSCOREPUTASITEMPATTINGGAL>();
            CreateMap<RFSCOREPUTASITEMPATTINGGALResponseDto, RFSCOREPUTASITEMPATTINGGAL>().ReverseMap();
        }
    }
}
