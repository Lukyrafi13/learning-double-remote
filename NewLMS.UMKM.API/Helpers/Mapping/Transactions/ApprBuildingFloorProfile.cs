using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprBuildingFloorProfile : Profile
    {
        public ApprBuildingFloorProfile()
        {
            CreateMap<ApprBuildingFloors, ApprBuildingFloorEntityResponse>()
            .ForMember(d => d.Description, s => s.MapFrom(s => s.FloorDescription));
        }
    }
}
