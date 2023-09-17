using AutoMapper;
using NewLMS.UMKM.Data.Dto.AppraisalVehicle;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprVehicleNoteProfile : Profile
    {
        public ApprVehicleNoteProfile()
        {
            CreateMap<ApprVehicleNote, ApprVehicleNoteResponse>();
        }   
    }
}
