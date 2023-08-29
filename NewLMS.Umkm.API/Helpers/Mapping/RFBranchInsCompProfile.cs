using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFBranchInsComps;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFBranchInsCompProfile : Profile
    {
        public RFBranchInsCompProfile()
        {
            CreateMap<RFBranchInsCompPostRequestDto, RFBranchInsComp>();
            CreateMap<RFBranchInsCompPutRequestDto, RFBranchInsComp>();
            CreateMap<RFBranchInsCompResponseDto, RFBranchInsComp>().ReverseMap();
        }
    }
}