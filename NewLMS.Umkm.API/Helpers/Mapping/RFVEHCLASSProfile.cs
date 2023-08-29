using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFVEHCLASSs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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