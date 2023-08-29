using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFLokasiUsahas;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFLokasiUsahaProfile : Profile
    {
        public RFLokasiUsahaProfile()
        {
            CreateMap<RFLokasiUsahaPostRequestDto, RFLokasiUsaha>();
            CreateMap<RFLokasiUsahaPutRequestDto, RFLokasiUsaha>();
            CreateMap<RFLokasiUsahaResponseDto, RFLokasiUsaha>().ReverseMap();
        }
    }
}