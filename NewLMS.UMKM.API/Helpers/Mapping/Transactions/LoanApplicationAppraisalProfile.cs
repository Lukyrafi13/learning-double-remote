using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationAppraisalProfile : Profile
    {
        public LoanApplicationAppraisalProfile()
        {
            CreateMap<LoanApplicationCollateral, ApprAssignmentDataListResponse>();
            CreateMap<LoanApplication, ApplicationInfoResponse>();
            CreateMap<LoanApplicationCollateral, AppraisalResponse>();
            CreateMap<LoanApplicationAppraisal, AppraisalResponse>();
            CreateMap<LoanApplicationAppraisal, AppraisalSimpleResponse>();
            CreateMap<LoanApplicationAppraisal, LoanApplicationAppraisalTableResponse>();
            CreateMap<LoanApplication, LoanApplicationAppInfoApprResponse>();
            

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
        }
    }
}
