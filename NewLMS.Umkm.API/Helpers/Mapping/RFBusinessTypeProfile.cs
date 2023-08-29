using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFBusinessTypes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFBusinessTypeProfile : Profile
    {
        public RFBusinessTypeProfile()
        {
            CreateMap<RFBusinessTypePostRequestDto, RFBusinessType>();
            CreateMap<RFBusinessTypePutRequestDto, RFBusinessType>();
            CreateMap<RFBusinessTypeResponseDto, RFBusinessType>().ReverseMap();
        }
    }
}