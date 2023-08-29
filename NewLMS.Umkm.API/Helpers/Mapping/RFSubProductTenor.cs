using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSubProductTenors;

namespace NewLMS.Umkm.API.Helpers.Mapping

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