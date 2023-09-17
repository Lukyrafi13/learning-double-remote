using AutoMapper;
using NewLMS.UMKM.Data.Dto.AppraisalVehicle;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprVehicleTemplateProfile : Profile
    {
        public ApprVehicleTemplateProfile()
        {
            CreateMap<ApprVehicleTemplate, ApprVehicleTemplateResponse>();
        }
    }
}
