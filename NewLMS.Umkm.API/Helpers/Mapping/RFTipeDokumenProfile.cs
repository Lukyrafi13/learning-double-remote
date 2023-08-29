using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFTipeDokumens;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFTipeDokumenProfile : Profile
    {
        public RFTipeDokumenProfile()
        {
            CreateMap<RFTipeDokumenPostRequestDto, RFTipeDokumen>();
            CreateMap<RFTipeDokumenPutRequestDto, RFTipeDokumen>();
            CreateMap<RFTipeDokumenResponseDto, RFTipeDokumen>().ReverseMap();
        }
    }
}
