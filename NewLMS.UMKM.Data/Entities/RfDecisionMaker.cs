using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfDecisionMaker : BaseEntity
    {
        public string DecisionMakerCode { get; set; }
        public string DecisionMakerDescription { get; set; }
    }
}
