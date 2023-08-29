using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFVEHMAKERs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFVEHMAKERProfile : Profile
    {
        public RFVEHMAKERProfile()
        {
            CreateMap<RFVEHMAKERPostRequestDto, RFVEHMAKER>();
            CreateMap<RFVEHMAKERPutRequestDto, RFVEHMAKER>();
            CreateMap<RFVEHMAKERResponseDto, RFVEHMAKER>().ReverseMap();
        }
    }
}