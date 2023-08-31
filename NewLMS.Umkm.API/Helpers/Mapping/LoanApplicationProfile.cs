using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.LoanApplications;

namespace NewLMS.UMKM.API.Helpers.MLoanApplicationing
{
    public class LoanApplicationProfile : Profile
    {
        public LoanApplicationProfile()
        {
            CreateMap<LoanApplicationIDEPutRequestDto, LoanApplication>().ReverseMap();
            // CreateMap<LoanApplicationGudang, LoanApplication>().ReverseMap();
            CreateMap<LoanApplicationPemohonBadanUsaha, LoanApplication>().ReverseMap();
            CreateMap<LoanApplicationPemohonPerorangan, LoanApplication>().ReverseMap();
            // CreateMap<LoanApplicationPemohonGapoktan, LoanApplication>().ReverseMap();
            CreateMap<LoanApplicationIDEPutRequestDtoResponse, LoanApplication>().ReverseMap();
            // CreateMap<LoanApplicationPilihanPemutusResponse, LoanApplication>().ReverseMap();
            CreateMap<LoanApplicationPemohonBadanUsahaResponse, LoanApplication>().ReverseMap();
            CreateMap<LoanApplicationPemohonBadanUsahaResponse, CompanyEntity>().ReverseMap();
            CreateMap<LoanApplicationPemohonPeroranganResponse, LoanApplication>().ReverseMap();
            // CreateMap<LoanApplicationPemohonGapoktanResponse, LoanApplication>().ReverseMap();

        }
    }
}
