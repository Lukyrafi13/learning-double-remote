using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFEDUCATIONs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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