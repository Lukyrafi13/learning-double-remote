using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFMARITALs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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