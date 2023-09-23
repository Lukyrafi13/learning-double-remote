using AutoMapper;
using NewLMS.Umkm.Data.Dto.ApprChecklistReviews;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class ApprChecklistReviewProfile : Profile
    {
        public ApprChecklistReviewProfile()
        {
            CreateMap<ApprChecklistReview, ApprChecklistReviewResponse>();
        }
    }
}
