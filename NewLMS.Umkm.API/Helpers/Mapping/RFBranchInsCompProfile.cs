using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFBranchInsComps;

namespace NewLMS.Umkm.API.Helpers.Mapping

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