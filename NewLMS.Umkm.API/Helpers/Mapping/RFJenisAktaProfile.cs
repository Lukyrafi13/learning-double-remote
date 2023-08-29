using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisAktas;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFJenisAktaProfile : Profile
    {
        public RFJenisAktaProfile()
        {
            CreateMap<RFJenisAktaPostRequestDto, RFJenisAkta>();
            CreateMap<RFJenisAktaPutRequestDto, RFJenisAkta>();
            CreateMap<RFJenisAktaResponseDto, RFJenisAkta>().ReverseMap();
        }
    }
}
