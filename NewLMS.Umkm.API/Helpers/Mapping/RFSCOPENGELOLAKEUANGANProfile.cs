using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOPENGELOLAKEUANGANs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSCOPENGELOLAKEUANGANProfile : Profile
    {
        public RFSCOPENGELOLAKEUANGANProfile()
        {
            CreateMap<RFSCOPENGELOLAKEUANGANPostRequestDto, RFSCOPENGELOLAKEUANGAN>();
            CreateMap<RFSCOPENGELOLAKEUANGANPutRequestDto, RFSCOPENGELOLAKEUANGAN>();
            CreateMap<RFSCOPENGELOLAKEUANGANResponseDto, RFSCOPENGELOLAKEUANGAN>().ReverseMap();
        }
    }
}