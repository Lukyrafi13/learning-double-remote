using AutoMapper;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
