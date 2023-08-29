using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFDebiturMemilikiUsahaLains;

namespace NewLMS.Umkm.API.Helpers.Mapping

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