using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFColLateralBCs

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFColLateralBCProfile : Profile
    {
        public RFColLateralBCProfile()
        {
            CreateMap<RFColLateralBCPostRequestDto, RFColLateralBC>();
            CreateMap<RFColLateralBCPutRequestDto, RFColLateralBC>();
            CreateMap<RFColLateralBCResponseDto, RFColLateralBC>().ReverseMap();
        }
    }
}
