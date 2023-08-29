using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFColLateralBCs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
