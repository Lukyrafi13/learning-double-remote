using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;

namespace NewLMS.UMKM.API.Helpers.MLoanApplicationing

{
    public class LoanApplicationKeyPersonProfile : Profile
    {
        public LoanApplicationKeyPersonProfile()
        {
            CreateMap<LoanApplicationKeyPersonPostRequestDto, LoanApplicationKeyPerson>();
            CreateMap<LoanApplicationKeyPersonPutRequestDto, LoanApplicationKeyPerson>();
            CreateMap<LoanApplicationKeyPersonResponseDto, LoanApplicationKeyPerson>().ReverseMap();
        }
    }
}