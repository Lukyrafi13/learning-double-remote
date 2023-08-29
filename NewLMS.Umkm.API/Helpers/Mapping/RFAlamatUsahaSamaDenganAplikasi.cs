using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;

namespace NewLMS.Umkm.API.Helpers.Mapping

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