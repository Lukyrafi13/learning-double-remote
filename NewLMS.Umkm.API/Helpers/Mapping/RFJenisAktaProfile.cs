using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisAktas;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
