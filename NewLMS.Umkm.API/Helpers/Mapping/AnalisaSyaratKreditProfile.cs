using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AnalisaSyaratKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class AnalisaSyaratKreditProfile : Profile
    {
        public AnalisaSyaratKreditProfile()
        {
            CreateMap<AnalisaSyaratKreditPostRequestDto, AnalisaSyaratKredit>();
            CreateMap<AnalisaSyaratKreditPutRequestDto, AnalisaSyaratKredit>();
            CreateMap<AnalisaSyaratKreditResponseDto, AnalisaSyaratKredit>().ReverseMap();
        }
    }
}