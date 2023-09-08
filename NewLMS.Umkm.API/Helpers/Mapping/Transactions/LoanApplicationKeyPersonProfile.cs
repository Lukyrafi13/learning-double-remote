using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationKeyPersonProfile : Profile
    {
        public LoanApplicationKeyPersonProfile()
        {
            CreateMap<LoanApplicationKeyPerson, LoanApplicationKeyPersonResponse>();
            CreateMap<LoanApplicationKeyPersonPostRequest, LoanApplicationKeyPerson>();
            CreateMap<LoanApplicationKeyPersonPutRequest, LoanApplicationKeyPerson>();
            CreateMap<LoanApplicationKeyPersonDeleteRequest, LoanApplicationKeyPerson>();
        }
    }
}
