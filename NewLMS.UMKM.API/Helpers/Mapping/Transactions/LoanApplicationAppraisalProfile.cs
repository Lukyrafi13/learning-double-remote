using AutoMapper;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationAppraisalProfile : Profile
    {
        public LoanApplicationAppraisalProfile()
        {
            CreateMap<LoanApplicationCollateral, ApprAssignmentDataListResponse>();
        }
    }
}
