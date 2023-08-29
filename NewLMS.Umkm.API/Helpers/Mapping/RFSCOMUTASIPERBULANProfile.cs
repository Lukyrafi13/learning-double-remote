using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOMUTASIPERBULANs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
