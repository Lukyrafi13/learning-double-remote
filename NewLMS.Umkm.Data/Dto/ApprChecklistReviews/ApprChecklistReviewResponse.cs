using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.ApprChecklistReviews
{
    public class ApprChecklistReviewResponse
    {
        public Guid ApprChecklistReviewGuid { get; set; }
        public Guid AppraisalGuid { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
        public string Yesno { get; set; }
        public string Remarks { get; set; }
    }
}
