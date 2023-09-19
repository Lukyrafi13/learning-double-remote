using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
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
