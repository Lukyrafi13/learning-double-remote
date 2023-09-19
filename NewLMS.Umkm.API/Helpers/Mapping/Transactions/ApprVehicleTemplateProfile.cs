using AutoMapper;
using NewLMS.Umkm.Data.Dto.AppraisalVehicle;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprVehicleTemplateProfile : Profile
    {
        public ApprVehicleTemplateProfile()
        {
            CreateMap<ApprVehicleTemplate, ApprVehicleTemplateResponse>();
            CreateMap<ApprVehicleTemplatePostRequest, ApprVehicleTemplate>();
        }
    }
}
