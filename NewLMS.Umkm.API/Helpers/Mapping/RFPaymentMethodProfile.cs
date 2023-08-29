using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFPaymentMethods;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFPaymentMethodProfile : Profile
    {
        public RFPaymentMethodProfile()
        {
            CreateMap<RFPaymentMethod, RFPaymentMethodResponseDto>().ReverseMap();
            CreateMap<RFPaymentMethodPostRequestDto, RFPaymentMethod>();
            CreateMap<RFPaymentMethodPutRequestDto, RFPaymentMethod>();
        }
    }
}