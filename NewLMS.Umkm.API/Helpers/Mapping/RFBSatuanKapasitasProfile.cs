using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSatuanKapasitass;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSatuanKapasitasProfile : Profile
    {
        public RFSatuanKapasitasProfile()
        {
            CreateMap<RFSatuanKapasitasPostRequestDto, RFSatuanKapasitas>();
            CreateMap<RFSatuanKapasitasPutRequestDto, RFSatuanKapasitas>();
            CreateMap<RFSatuanKapasitasResponseDto, RFSatuanKapasitas>().ReverseMap();
        }
    }
}