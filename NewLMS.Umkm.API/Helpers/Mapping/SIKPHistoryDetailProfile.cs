using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SIKPHistoryDetails;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class SIKPHistoryDetailProfile : Profile
    {
        public SIKPHistoryDetailProfile()
        {
            CreateMap<SIKPHistoryDetailPostRequestDto, SIKPHistoryDetail>();
            CreateMap<SIKPHistoryDetailPutRequestDto, SIKPHistoryDetail>();
            CreateMap<SIKPHistoryDetailResponseDto, SIKPHistoryDetail>().ReverseMap();
        }
    }
}