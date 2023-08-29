using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFLokasiTempatUsahas;

namespace NewLMS.UMKM.API.Helpers.Mapping

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