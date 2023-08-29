using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFDebiturMemilikiUsahaLainProfile : Profile
    {
        public RFDebiturMemilikiUsahaLainProfile()
        {
            CreateMap<RFDebiturMemilikiUsahaLainPostRequestDto, DebiturMemilikiUsahaLain>();
            CreateMap<RFDebiturMemilikiUsahaLainPutRequestDto, DebiturMemilikiUsahaLain>();
            CreateMap<RFDebiturMemilikiUsahaLainResponseDto, DebiturMemilikiUsahaLain>().ReverseMap();
        }
    }
}