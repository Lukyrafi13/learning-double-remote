using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFPengikatanKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
