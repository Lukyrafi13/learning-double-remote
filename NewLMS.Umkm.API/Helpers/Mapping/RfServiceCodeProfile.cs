using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfServiceCodeProfile : Profile
    {
        public RfServiceCodeProfile()
        {
            CreateMap<RfServiceCode, RfServiceCodeResponseDto>();
        }
    }
}