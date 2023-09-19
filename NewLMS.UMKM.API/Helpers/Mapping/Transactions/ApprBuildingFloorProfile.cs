using AutoMapper;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
