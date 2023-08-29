using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOPENGELOLAKEUANGANs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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