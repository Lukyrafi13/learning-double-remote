using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationFieldSurveyDetailProfile : Profile
    {
        public LoanApplicationFieldSurveyDetailProfile()
        {
            CreateMap<LoanApplicationFieldSurveyDetail, LoanApplicationFieldSurveyDetailsResponse>();
            CreateMap<LoanApplicationFieldSurveyDetailsPostRequest, LoanApplicationFieldSurveyDetail>();
            CreateMap<LoanApplicationFIeldSurveyDetailsPutRequest, LoanApplicationFieldSurveyDetail>();
            CreateMap<LoanApplicationFieldSurveyDetailsDeleteRequest, LoanApplicationFieldSurveyDetail>();
        }
    }
}
