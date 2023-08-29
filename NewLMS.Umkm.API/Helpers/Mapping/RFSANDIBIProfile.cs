using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSANDIBIS;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFSANDIBIProfile : Profile
    {
        public RFSANDIBIProfile()
        {
            CreateMap<RFSANDIBIPostRequestDto, RFSANDIBI>();
            CreateMap<RFSANDIBIPutRequestDto, RFSANDIBI>();
            CreateMap<RFSANDIBIResponseDto, RFSANDIBI>().ReverseMap();
        }
    }
}
