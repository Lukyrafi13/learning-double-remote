using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFLokasiTempatUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFLokasiTempatUsahaProfile : Profile
    {
        public RFLokasiTempatUsahaProfile()
        {
            CreateMap<RFLokasiTempatUsahaPostRequestDto, RFLokasiTempatUsaha>();
            CreateMap<RFLokasiTempatUsahaPutRequestDto, RFLokasiTempatUsaha>();
            CreateMap<RFLokasiTempatUsahaResponseDto, RFLokasiTempatUsaha>().ReverseMap();
        }
    }
}