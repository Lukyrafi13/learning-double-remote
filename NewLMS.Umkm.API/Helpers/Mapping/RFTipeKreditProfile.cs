using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfCreditTypeProfile : Profile
    {
        public RfCreditTypeProfile()
        {
            CreateMap<RfCreditTypePostRequestDto, RfCreditType>();
            CreateMap<RfCreditTypePutRequestDto, RfCreditType>();
            CreateMap<RfCreditTypeResponseDto, RfCreditType>().ReverseMap();
        }
    }
}