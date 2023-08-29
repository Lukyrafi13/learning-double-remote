using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFBusinessTypes;

namespace NewLMS.Umkm.API.Helpers.Mapping

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