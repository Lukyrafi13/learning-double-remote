using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfBranchess;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfBranchesProfile : Profile
    {
        public RfBranchesProfile()
        {
            CreateMap<RfBranches, RfBranchesResponseDto>().ReverseMap();
            CreateMap<RfBranchesPostRequestDto, RfBranches>();
            CreateMap<RfBranchesPutRequestDto, RfBranches>();
        }
    }
}