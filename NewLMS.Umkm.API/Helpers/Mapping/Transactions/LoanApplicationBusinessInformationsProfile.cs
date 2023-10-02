using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationBusinessInformations;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationBusinessInformationsProfile : Profile
    {
        public LoanApplicationBusinessInformationsProfile()
        {
            CreateMap<LoanApplicationBusinessInformation, LoanApplicationBusinessInformationResponse>();
            CreateMap<LoanApplicationBusinessInformationRequest, LoanApplicationBusinessInformation > ();
        }
    }
}
