using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AnalisaAsuransis;

namespace NewLMS.UMKM.API.Helpers.Mapping

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