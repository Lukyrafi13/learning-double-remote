using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFTipeDokumens;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
