using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFLinkages;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
