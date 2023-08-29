using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class AnalisaFasilitasProfile : Profile
    {
        public AnalisaFasilitasProfile()
        {
            CreateMap<AnalisaFasilitasPostRequestDto, AnalisaFasilitas>();
            CreateMap<AnalisaFasilitasPutRequestDto, AnalisaFasilitas>();
            CreateMap<AnalisaFasilitasResponseDto, AnalisaFasilitas>().ReverseMap();
        }
    }
}