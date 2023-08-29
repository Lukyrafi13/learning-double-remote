using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFLokasiUsahas;

namespace NewLMS.Umkm.API.Helpers.Mapping

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