using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisTempatUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJenisTempatUsahaProfile : Profile
    {
        public RFJenisTempatUsahaProfile()
        {
            CreateMap<RFJenisTempatUsahaPostRequestDto, RFJenisTempatUsaha>();
            CreateMap<RFJenisTempatUsahaPutRequestDto, RFJenisTempatUsaha>();
            CreateMap<RFJenisTempatUsahaResponseDto, RFJenisTempatUsaha>().ReverseMap();
        }
    }
}