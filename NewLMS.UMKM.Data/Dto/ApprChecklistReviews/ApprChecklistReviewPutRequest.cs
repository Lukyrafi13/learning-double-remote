using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.ApprChecklistReviews
{
    public class ApprChecklistReviewPutRequest : ApprChecklistReviewPostRequest
    {
        public Guid ApprChecklistReviewGuid { get; set; }

    }
}
