using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfBranches;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfBranchProfile : Profile
    {
        public RfBranchProfile()
        {
            CreateMap<RfBranch, RfBranchResponseDto>().ReverseMap();
            CreateMap<RfBranchPostRequestDto, RfBranch>();
            CreateMap<RfBranchPutRequestDto, RfBranch>();
        }
    }
}