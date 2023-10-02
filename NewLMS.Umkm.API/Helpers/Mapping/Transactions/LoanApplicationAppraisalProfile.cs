using AutoMapper;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationAppraisalProfile : Profile
    {
        public LoanApplicationAppraisalProfile()
        {
            CreateMap<LoanApplicationCollateral, ApprAssignmentDataListResponse>();
            CreateMap<LoanApplicationAppraisal, LoanApplicationApprSurveyorTableResponse>();
            CreateMap<LoanApplication, ApplicationInfoResponse>();
            CreateMap<LoanApplicationCollateral, AppraisalResponse>();
            CreateMap<LoanApplicationAppraisal, AppraisalResponse>();
            CreateMap<LoanApplicationAppraisal, AppraisalSimpleResponse>();
            CreateMap<LoanApplicationAppraisal, LoanApplicationAppraisalTableResponse>();



            CreateMap<LoanApplication, LoanApplicationAppInfoApprResponse>();
            CreateMap<LoanApplicationAppraisal, LoanApplicationAppInfoApprSurveyorResponse>();
            

            CreateMap<LoanApplicationAppraisal, LoanApplicationApprAsignmentResponse>()
                .ForMember(d => d.PropertyCategory, o =>
                {
                    o.MapFrom(s => s ?? new LoanApplicationAppraisal());
                })
                .ForMember(d => d.LoanApplicationInfo, o =>
                {
                    o.MapFrom(s => s.LoanApplication ?? new LoanApplication());
                })
                .ForMember(d => d.LoanApplicationCollateral, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollateral ?? new LoanApplicationCollateral());
                })
                ;

            CreateMap<LoanApplicationAppraisal, LoanApplicationApprSurveyorResponse>()
                .ForMember(d => d.PropertyCategory, o =>
                {
                    o.MapFrom(s => s ?? new LoanApplicationAppraisal());
                })
                .ForMember(d => d.LoanApplicationInfo, o =>
                {
                    o.MapFrom(s => s.LoanApplication ?? new LoanApplication());
                })
                .ForMember(d => d.LoanApplicationCollateral, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollateral ?? new LoanApplicationCollateral());
                })
                ;
        }
    }
}
