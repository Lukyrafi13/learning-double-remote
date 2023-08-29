using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;

namespace NewLMS.Umkm.API.Helpers.Mapping

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