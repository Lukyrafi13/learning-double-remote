using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFLamaUsahaLains;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFLamaUsahaLainProfile : Profile
    {
        public RFLamaUsahaLainProfile()
        {
            CreateMap<RFLamaUsahaLainPostRequestDto, RFLamaUsahaLain>();
            CreateMap<RFLamaUsahaLainPutRequestDto, RFLamaUsahaLain>();
            CreateMap<RFLamaUsahaLainResponseDto, RFLamaUsahaLain>().ReverseMap();
        }
    }
}