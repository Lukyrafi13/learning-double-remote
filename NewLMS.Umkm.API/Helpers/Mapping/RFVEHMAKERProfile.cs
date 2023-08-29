using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFVEHMAKERs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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