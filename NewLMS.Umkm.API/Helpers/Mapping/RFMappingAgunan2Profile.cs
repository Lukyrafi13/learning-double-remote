using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFMappingAgunan2Profile : Profile
    {
        public RFMappingAgunan2Profile()
        {
            CreateMap<RFMappingAgunan2PostRequestDto, RFMappingAgunan2>();
            CreateMap<RFMappingAgunan2PutRequestDto, RFMappingAgunan2>();
            CreateMap<RFMappingAgunan2ResponseDto, RFMappingAgunan2>().ReverseMap();
        }
    }
}
