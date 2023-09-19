using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Entities;
using System;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationPrescreeningProfile : Profile
    {
        public LoanApplicationPrescreeningProfile()
        {
            CreateMap<LoanApplication, LoanApplicationPrescreeningsTableResponse>()
                .ForMember(d => d.DebtorName, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.ParameterDetailId == 1 ? s.Debtor.Fullname : s.DebtorCompany.Name);
                })
                .ForMember(d => d.DebtorDateOfBirth, o =>
                {
                    o.MapFrom(s => s.RfOwnerCategory.ParameterDetailId == 1 ? s.Debtor.DateOfBirth : null);
                })
                .ForMember(d => d.SlikStatus, o =>
                {
                    o.MapFrom(s => "1/1");
                })
                .ForMember(d => d.RequestDate, o =>
                {
                    o.MapFrom(s => DateTime.Now);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationPrescreeningResponse>()
                .ForMember(d => d.InfoPrescreening, o =>
                {
                    o.MapFrom(s => s);
                })
                .ForMember(d => d.LoanApplicationRAC, o =>
                {
                    o.MapFrom(s => s.LoanApplicationRAC);
                })
                ;

            CreateMap<LoanApplication, LoanApplicationPrescreeningBaseTabReponse>();
        }   
    }
}
