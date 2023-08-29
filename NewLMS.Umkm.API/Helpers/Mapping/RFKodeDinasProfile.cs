using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFKodeDinass;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFKodeDinasProfile : Profile
    {
        public RFKodeDinasProfile()
        {
            CreateMap<RFKodeDinas, RFKodeDinasResponseDto>();
        }
    }
}