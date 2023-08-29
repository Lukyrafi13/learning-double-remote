using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SIKPHistorys;

namespace NewLMS.Umkm.API.Helpers.Mapping

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