using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
