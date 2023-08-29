using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFKelompokUsahaProfile : Profile
    {
        public RFKelompokUsahaProfile()
        {
            CreateMap<RFKelompokUsahaPostRequestDto, RFKelompokUsaha>();
            CreateMap<RFKelompokUsahaPutRequestDto, RFKelompokUsaha>();
            CreateMap<RFKelompokUsahaResponseDto, RFKelompokUsaha>().ReverseMap();
        }
    }
}