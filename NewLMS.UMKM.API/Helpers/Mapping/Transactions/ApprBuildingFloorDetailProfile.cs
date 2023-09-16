using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprBuildingFloorDetailProfile : Profile
    {
        public ApprBuildingFloorDetailProfile()
        {
            CreateMap<ApprBuildingFloorDetails, ApprBuildingFloorDetailResponse>()
            .ForMember(d => d.Description, s => s.MapFrom(s => s.FloorDescription));
        }
    }
}
