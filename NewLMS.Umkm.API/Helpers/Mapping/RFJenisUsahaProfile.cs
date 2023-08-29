using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJenisUsahaProfile : Profile
    {
        public RFJenisUsahaProfile()
        {
            CreateMap<RFJenisUsahaPostRequestDto, RFJenisUsaha>();
            CreateMap<RFJenisUsahaPutRequestDto, RFJenisUsaha>();
            CreateMap<RFJenisUsahaResponseDto, RFJenisUsaha>().ReverseMap();
        }
    }
}