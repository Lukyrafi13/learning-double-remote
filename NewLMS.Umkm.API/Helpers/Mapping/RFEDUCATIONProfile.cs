using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFEDUCATIONs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFEDUCATIONProfile : Profile
    {
        public RFEDUCATIONProfile()
        {
            CreateMap<RFEDUCATIONPostRequestDto, RFEDUCATION>();
            CreateMap<RFEDUCATIONPutRequestDto, RFEDUCATION>();
            CreateMap<RFEDUCATIONResponseDto, RFEDUCATION>().ReverseMap();
        }
    }
}