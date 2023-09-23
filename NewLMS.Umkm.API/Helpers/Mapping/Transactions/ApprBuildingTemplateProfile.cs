using AutoMapper;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using System;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprBuildingTemplateProfile : Profile
    {
        public ApprBuildingTemplateProfile()
        {
            CreateMap<ApprBuildingTemplates, ApprBuildingTemplateResponse>()
            .ForMember(d => d.DebtorName, s => s.MapFrom(s =>
                s.LoanApplicationAppraisal.LoanApplication.OwnerCategoryId == 1 ? s.LoanApplicationAppraisal.LoanApplication.Debtor.Fullname : s.LoanApplicationAppraisal.LoanApplication.DebtorCompany.Name
            ))
            .ForMember(d => d.Pondation, s => s.MapFrom(s => s.FoundationFK))
            .ForMember(d => d.Wall, s => s.MapFrom(s => s.WallFK))
            .ForMember(d => d.Floor, s => s.MapFrom(s => s.FloorFK))
            .ForMember(d => d.RoofTruss, s => s.MapFrom(s => s.RoofTrussFK))
            .ForMember(d => d.Roof, s => s.MapFrom(s => s.RoofFK))
            .ForMember(d => d.InnerWall, s => s.MapFrom(s => s.InnerWallFK))
            .ForMember(d => d.Sills, s => s.MapFrom(s => s.SillsFK))
            .ForMember(d => d.Plafond, s => s.MapFrom(s => s.PlafondFK))
            .ForMember(d => d.ElectricConn, s => s.MapFrom(s => s.ElectricConnFK))
            .ForMember(d => d.CleanWater, s => s.MapFrom(s => s.CleanWaterFK))
            .ForMember(d => d.Phone, s => s.MapFrom(s => s.PhoneFK))
            .ForMember(d => d.ArchitectShape, s => s.MapFrom(s => s.ArchitectShapeFK))
            .ForMember(d => d.BuildingCondition, s => s.MapFrom(s => s.BuildingConditionFK))
            .ForMember(d => d.YardCondition, s => s.MapFrom(s => s.YardConditionFK))
            .ForMember(d => d.Fence, s => s.MapFrom(s => s.FenceFK))
            .ForMember(d => d.Remarks, s => s.MapFrom(s => s.Remark));

            CreateMap<AppraisalBuildingTemplatePostRequest, ApprBuildingTemplates>()
            .ForMember(d => d.Foundation, s => s.MapFrom(s => s.Pondation))
            .ForMember(d => d.Remark, s => s.MapFrom(s => s.Remarks));
        }
    }
}
