using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSubProductTenorProfile : Profile
    {
        public RFSubProductTenorProfile()
        {
            CreateMap<RFSubProductTenorPostRequestDto, RFSubProductTenor>();
            CreateMap<RFSubProductTenorPutRequestDto, RFSubProductTenor>();
            CreateMap<RFSubProductTenorResponseDto, RFSubProductTenor>().ReverseMap();
            CreateMap<RFSubProductTenorDetailResponseDto, RFSubProductTenor>().ReverseMap();
        }
    }
}