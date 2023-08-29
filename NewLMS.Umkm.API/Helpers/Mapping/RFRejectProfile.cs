using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFRejects;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFRejectProfile : Profile
    {
        public RFRejectProfile()
        {
            CreateMap<RFReject, RFRejectResponseDto>().ReverseMap();
            CreateMap<RFRejectPostRequestDto, RFReject>();
            CreateMap<RFRejectPutRequestDto, RFReject>();
        }
    }
}