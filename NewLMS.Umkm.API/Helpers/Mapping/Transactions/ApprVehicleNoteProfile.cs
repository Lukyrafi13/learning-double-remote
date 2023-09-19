using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalVehicle;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprVehicleNoteProfile : Profile
    {
        public ApprVehicleNoteProfile()
        {
            CreateMap<ApprVehicleNote, ApprVehicleNoteResponse>();
        }   
    }
}
