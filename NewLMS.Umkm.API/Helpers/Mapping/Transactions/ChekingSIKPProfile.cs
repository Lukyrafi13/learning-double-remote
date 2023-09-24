using AutoMapper;
using NewLMS.Umkm.Data.Dto.ChekingSIKPs;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ChekingSIKPProfile : Profile
    {
        public ChekingSIKPProfile()
        {
            CreateMap<SIKPHistory, ChekingSIKPHistoryResponse>()
                .ForMember(d => d.SIKPHistoryDetails, o =>
                {
                    o.MapFrom(s => s.SIKPHistoryDetails);
                });
            CreateMap<SIKPHistoryDetail, ChekingSIKPHistoryDetailResponse>();
        }
    }
}
