using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFRejects;

namespace NewLMS.Umkm.API.Helpers.Mapping

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