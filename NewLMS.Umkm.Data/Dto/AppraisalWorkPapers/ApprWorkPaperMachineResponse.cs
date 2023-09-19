using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprWorkPaperMachineResponse
    {
        public SimpleResponse<Guid> ApproachType { get; set; }
        public List<SimpleResponse<Guid>> ApproachTypeReference { get; set; }
    }
}
