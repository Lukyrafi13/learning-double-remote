using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSCOTINGKATKEBUTUHANs;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSCOTINGKATKEBUTUHANProfile : Profile
    {
        public RFSCOTINGKATKEBUTUHANProfile()
        {
            CreateMap<RFSCOTINGKATKEBUTUHANPostRequestDto, RFSCOTINGKATKEBUTUHAN>();
            CreateMap<RFSCOTINGKATKEBUTUHANPutRequestDto, RFSCOTINGKATKEBUTUHAN>();
            CreateMap<RFSCOTINGKATKEBUTUHANResponseDto, RFSCOTINGKATKEBUTUHAN>().ReverseMap();
        }
    }
}
