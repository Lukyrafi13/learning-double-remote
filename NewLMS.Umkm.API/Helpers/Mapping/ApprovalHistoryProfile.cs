using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.ApprovalHistorys;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class ApprovalHistoryProfile : Profile
    {
        public ApprovalHistoryProfile()
        {
            CreateMap<ApprovalHistory, ApprovalHistoryResponseDto>().ReverseMap();
            CreateMap<ApprovalHistoryPostRequestDto, ApprovalHistory>();
            CreateMap<ApprovalHistoryPutRequestDto, ApprovalHistory>();
        }
    }
}