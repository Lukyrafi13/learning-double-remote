using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSubProducts;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFSubProductProfile : Profile
    {
        public RFSubProductProfile()
        {
            CreateMap<RFSubProductPostRequestDto, RFSubProduct>();
            CreateMap<RFSubProductPutRequestDto, RFSubProduct>();
            CreateMap<RFSubProductResponseDto, RFSubProduct>().ReverseMap();
        }
    }
}