using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFCSBPHeaders;

namespace NewLMS.Umkm.API.Helpers.Mapping

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