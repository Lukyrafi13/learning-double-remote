using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFTenors;

namespace NewLMS.UMKM.API.Helpers.Mapping

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