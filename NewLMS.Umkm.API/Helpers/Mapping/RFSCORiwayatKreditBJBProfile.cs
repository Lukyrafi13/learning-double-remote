using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCORiwayatKreditBJBs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSCORiwayatKreditBJBProfile : Profile
    {
        public RFSCORiwayatKreditBJBProfile()
        {
            CreateMap<RFSCORiwayatKreditBJBPostRequestDto, RFSCORiwayatKreditBJB>();
            CreateMap<RFSCORiwayatKreditBJBPutRequestDto, RFSCORiwayatKreditBJB>();
            CreateMap<RFSCORiwayatKreditBJBResponseDto, RFSCORiwayatKreditBJB>().ReverseMap();
        }
    }
}
