using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
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
            CreateMap<Appraisal, AppraisalResponse>();
            CreateMap<Appraisal, LoanApplicationAppraisalTableResponse>();

            CreateMap<Appraisal, LoanApplicationApprAsignmentResponse>()
                .ForMember(d => d.LoanApplicationInfo, o =>
                {
                    o.MapFrom(s => s.LoanApplication);
                })
                .ForMember(d => d.PropertyCategory, o =>
                {
                    o.MapFrom(s => s);
                })
                .ForMember(d => d.LoanApplicationCollateral, o =>
                {
                    o.MapFrom(s => s.LoanApplicationCollateral);
                })
                ;
        }
    }
}
