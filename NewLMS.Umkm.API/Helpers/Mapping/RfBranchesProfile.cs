using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RfBranchess;

namespace NewLMS.Umkm.API.Helpers.Mapping

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