using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFOwnerOTSs;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFOwnerOTSProfile : Profile
    {
        public RFOwnerOTSProfile()
        {
            CreateMap<RFOwnerOTSPostRequestDto, RFOwnerOTS>();
            CreateMap<RFOwnerOTSPutRequestDto, RFOwnerOTS>();
            CreateMap<RFOwnerOTSResponseDto, RFOwnerOTS>().ReverseMap();
        }
    }
}