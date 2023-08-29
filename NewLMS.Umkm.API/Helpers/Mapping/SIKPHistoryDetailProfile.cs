using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SIKPHistoryDetails;

namespace NewLMS.UMKM.API.Helpers.Mapping

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