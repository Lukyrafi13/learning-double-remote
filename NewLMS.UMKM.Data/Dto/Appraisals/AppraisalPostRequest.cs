using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class AppraisalPostRequest
    {
        public Guid LoanApplicationCollateralId { get; set; }
        public Boolean isInternal { get; set; }
        public Boolean isExternal { get; set; }
        public string Estimator { get; set; }
        public string Kjpp { get; set; }
        public string PropertyCategory { get; set; }
        public string AppraisalStatus { get; set; }
    }
}
