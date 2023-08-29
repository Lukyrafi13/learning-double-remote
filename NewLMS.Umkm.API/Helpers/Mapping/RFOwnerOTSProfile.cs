using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFOwnerOTSs;

namespace NewLMS.Umkm.API.Helpers.Mapping

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