using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFPaymentMethods;

namespace NewLMS.Umkm.API.Helpers.Mapping

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