using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalResults
{
    public class CollateralBindingRequest
    {
        public string CollateralBindingGuid { get; set; }
        public string CollateralCode { get; set; }
        public Guid? BindingTypeGuid { get; set; }
        public Guid? FacilityGuid { get; set; }
        public Guid? BindingGuid { get; set; }
        public string BindingValue { get; set; }
        public string BindingRank { get; set; }
    }
}
