using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFLinkages;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFLinkageProfile : Profile
    {
        public RFLinkageProfile()
        {
            CreateMap<RFLinkagePostRequestDto, RFLinkage>();
            CreateMap<RFLinkagePutRequestDto, RFLinkage>();
            CreateMap<RFLinkageResponseDto, RFLinkage>().ReverseMap();
        }
    }
}
