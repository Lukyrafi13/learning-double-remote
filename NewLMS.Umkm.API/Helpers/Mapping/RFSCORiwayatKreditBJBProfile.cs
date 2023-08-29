using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCORiwayatKreditBJBs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
