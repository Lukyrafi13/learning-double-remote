using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AnalisaFasilitass;

namespace NewLMS.UMKM.API.Helpers.Mapping

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