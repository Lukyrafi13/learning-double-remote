using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycles;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfBusinessPrimaryCiclusProfile : Profile
    {
        public RfBusinessPrimaryCiclusProfile()
        {
            CreateMap<RfBusinessPrimaryCiclusPostRequestDto, RfBusinessPrimaryCycle>();
            CreateMap<RFSiklusUsahaPokokPutRequestDto, RfBusinessPrimaryCycle>();
            CreateMap<RfBusinessPrimaryCicleResponseDto, RfBusinessPrimaryCycle>().ReverseMap();
        }
    }
}