using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationVerificationNeedDetailProfile : Profile
    {
        public LoanApplicationVerificationNeedDetailProfile()
        {
            CreateMap<LoanApplicationVerificationNeedDetail, LoanApplicationVerificationNeedDetailsResponse>();
            CreateMap<LoanApplicationVerificationNeedDetailPostRequest, LoanApplicationVerificationNeedDetail>();
            CreateMap<LoanApplicationVerificationNeedDetailPutRequest, LoanApplicationVerificationNeedDetail>();
            CreateMap<LoanApplicationVerificationNeedDetailDeleteRequest, LoanApplicationVerificationNeedDetail>();
        }
    }
}
