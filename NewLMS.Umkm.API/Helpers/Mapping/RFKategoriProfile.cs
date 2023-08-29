using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFKategoris;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFKategoriProfile : Profile
    {
        public RFKategoriProfile()
        {
            CreateMap<RFKategoriPostRequestDto, RFKategori>();
            CreateMap<RFKategoriPutRequestDto, RFKategori>();
            CreateMap<RFKategoriResponseDto, RFKategori>().ReverseMap();
        }
    }
}