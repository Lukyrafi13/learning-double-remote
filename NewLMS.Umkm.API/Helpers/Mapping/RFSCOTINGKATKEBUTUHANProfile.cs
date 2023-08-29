using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSCOTINGKATKEBUTUHANs;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
