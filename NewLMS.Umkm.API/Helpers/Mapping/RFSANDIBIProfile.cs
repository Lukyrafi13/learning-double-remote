using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSANDIBIS;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
