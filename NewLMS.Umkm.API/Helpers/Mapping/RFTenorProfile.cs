using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFTenors;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFTenorProfile : Profile
    {
        public RFTenorProfile()
        {
            CreateMap<RFTenorPostRequestDto, RFTenor>();
            CreateMap<RFTenorPutRequestDto, RFTenor>();
            CreateMap<RFTenorResponseDto, RFTenor>().ReverseMap();
            CreateMap<RFTenorShortResponseDto, RFTenor>().ReverseMap();
        }
    }
}