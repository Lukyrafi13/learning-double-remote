using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFPengikatanKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFPengikatanKreditProfile : Profile
    {
        public RFPengikatanKreditProfile()
        {
            CreateMap<RFPengikatanKreditPostRequestDto, RFPengikatanKredit>();
            CreateMap<RFPengikatanKreditPutRequestDto, RFPengikatanKredit>();
            CreateMap<RFPengikatanKreditResponseDto, RFPengikatanKredit>().ReverseMap();
        }
    }
}
