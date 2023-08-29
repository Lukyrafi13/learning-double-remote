using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
