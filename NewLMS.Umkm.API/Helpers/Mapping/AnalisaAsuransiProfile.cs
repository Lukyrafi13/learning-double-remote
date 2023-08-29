using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AnalisaAsuransis;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class AnalisaAsuransiProfile : Profile
    {
        public AnalisaAsuransiProfile()
        {
            CreateMap<AnalisaAsuransiPostRequestDto, AnalisaAsuransi>();
            CreateMap<AnalisaAsuransiPutRequestDto, AnalisaAsuransi>();
            CreateMap<AnalisaAsuransiResponseDto, AnalisaAsuransi>().ReverseMap();
        }
    }
}