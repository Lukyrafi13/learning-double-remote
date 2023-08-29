using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFCSBPHeaders;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFCSBPHeaderProfile : Profile
    {
        public RFCSBPHeaderProfile()
        {
            CreateMap<RFCSBPHeaderPostRequestDto, RFCSBPHeader>();
            CreateMap<RFCSBPHeaderPutRequestDto, RFCSBPHeader>();
            CreateMap<RFCSBPHeaderResponseDto, RFCSBPHeader>().ReverseMap();
        }
    }
}