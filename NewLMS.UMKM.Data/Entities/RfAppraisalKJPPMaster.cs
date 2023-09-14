using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfAppraisalKJPPMaster : BaseEntity
    {
        public string KJPPMasterCode { get; set; }
        public string KJPPName { get; set; }
        public string PKSStartDate { get; set; }
        public string PKSEndDate { get; set; }
        public string CoreCode { get; set; }
        public string Active { get; set; }
    }
}
