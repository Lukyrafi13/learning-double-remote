using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFMARITALs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFMARITALProfile : Profile
    {
        public RFMARITALProfile()
        {
            CreateMap<RFMARITALPostRequestDto, RFMARITAL>();
            CreateMap<RFMARITALPutRequestDto, RFMARITAL>();
            CreateMap<RFMARITALResponseDto, RFMARITAL>().ReverseMap();
        }
    }
}