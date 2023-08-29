using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFVEHCLASSs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFVEHCLASSProfile : Profile
    {
        public RFVEHCLASSProfile()
        {
            CreateMap<RFVEHCLASSPostRequestDto, RFVEHCLASS>();
            CreateMap<RFVEHCLASSPutRequestDto, RFVEHCLASS>();
            CreateMap<RFVEHCLASSResponseDto, RFVEHCLASS>().ReverseMap();
        }
    }
}