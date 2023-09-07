using AutoMapper;
using NewLMS.UMKM.Data.Dto.DebtorCouple;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class DebtorCoupleProfile : Profile
    {
        public DebtorCoupleProfile()
        {
            CreateMap<DebtorCouple, DebtorCoupleResponse>();
            CreateMap<DebtorCouplePostRequest, DebtorCouple>();
        }
    }
}
