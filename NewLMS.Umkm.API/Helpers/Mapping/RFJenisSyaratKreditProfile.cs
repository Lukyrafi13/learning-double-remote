using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisSyaratKredits;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFJenisSyaratKreditProfile : Profile
    {
        public RFJenisSyaratKreditProfile()
        {
            CreateMap<RFJenisSyaratKreditPostRequestDto, RFJenisSyaratKredit>();
            CreateMap<RFJenisSyaratKreditPutRequestDto, RFJenisSyaratKredit>();
            CreateMap<RFJenisSyaratKreditResponseDto, RFJenisSyaratKredit>().ReverseMap();
        }
    }
}
