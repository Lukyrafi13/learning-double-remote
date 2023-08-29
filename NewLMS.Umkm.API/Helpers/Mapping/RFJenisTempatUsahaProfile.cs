using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas;

namespace NewLMS.UMKM.API.Helpers.Mapping

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