using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFAlamatUsahaSamaDenganAplikasiProfile : Profile
    {
        public RFAlamatUsahaSamaDenganAplikasiProfile()
        {
            CreateMap<RFAlamatUsahaSamaDenganAplikasiPostRequestDto, AlamatUsahaSamaDenganAplikasi>();
            CreateMap<RFAlamatUsahaSamaDenganAplikasiPutRequestDto, AlamatUsahaSamaDenganAplikasi>();
            CreateMap<RFAlamatUsahaSamaDenganAplikasiResponseDto, AlamatUsahaSamaDenganAplikasi>().ReverseMap();
        }
    }
}