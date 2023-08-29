using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.ApprovalHistorys;

namespace NewLMS.UMKM.API.Helpers.Mapping

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