using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Approvals;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
