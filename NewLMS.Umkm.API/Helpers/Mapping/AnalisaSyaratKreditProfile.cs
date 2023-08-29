using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AnalisaSyaratKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping

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