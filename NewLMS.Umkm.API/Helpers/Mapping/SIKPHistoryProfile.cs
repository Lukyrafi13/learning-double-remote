using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SIKPHistorys;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SIKPHistoryProfile : Profile
    {
        public SIKPHistoryProfile()
        {
            CreateMap<SIKPHistoryPostRequestDto, SIKPHistory>();
            CreateMap<SIKPHistoryDetailDTO, SIKPHistoryDetail>();
            CreateMap<SIKPHistoryPutRequestDto, SIKPHistory>();
            CreateMap<SIKPHistoryResponseDto, SIKPHistory>().ReverseMap();
        }
    }
}