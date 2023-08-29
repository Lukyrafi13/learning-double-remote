using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFLamaUsahaLains;

namespace NewLMS.UMKM.API.Helpers.Mapping

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