using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJenisUsahaMapProfile : Profile
    {
        public RFJenisUsahaMapProfile()
        {
            CreateMap<RFJenisUsahaMapPostRequestDto, RFJenisUsahaMap>();
            CreateMap<RFJenisUsahaMapPutRequestDto, RFJenisUsahaMap>();
            CreateMap<RFJenisUsahaMapResponseDto, RFJenisUsahaMap>().ReverseMap();
            CreateMap<RFJenisUsahaByKelompokResponse, RFJenisUsahaMap>().ReverseMap();
        }
    }
}