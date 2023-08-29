using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Approvals;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class ApprovalProfile : Profile
    {
        public ApprovalProfile()
        {
            CreateMap<Approval, ApprovalApprovalPutRequestDto>().ReverseMap();
            CreateMap<Approval, ApprovalApprovalResponse>().ReverseMap();
        }
    }
}
