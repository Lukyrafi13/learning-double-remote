using AutoMapper;
using NewLMS.UMKM.Data.Dto.ApprChecklistReviews;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
{
    public class ApprChecklistReviewProfile : Profile
    {
        public ApprChecklistReviewProfile()
        {
            CreateMap<ApprChecklistReview, ApprChecklistReviewResponse>();
        }
    }
}
