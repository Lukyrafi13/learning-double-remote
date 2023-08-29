using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOMUTASIPERBULANs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSCOMUTASIPERBULANProfile : Profile
    {
        public RFSCOMUTASIPERBULANProfile()
        {
            CreateMap<RFSCOMUTASIPERBULANPostRequestDto, RFSCOMUTASIPERBULAN>();
            CreateMap<RFSCOMUTASIPERBULANPutRequestDto, RFSCOMUTASIPERBULAN>();
            CreateMap<RFSCOMUTASIPERBULANResponseDto, RFSCOMUTASIPERBULAN>().ReverseMap();
        }
    }
}
