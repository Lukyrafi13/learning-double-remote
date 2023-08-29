using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSubProducts;

namespace NewLMS.UMKM.API.Helpers.Mapping

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